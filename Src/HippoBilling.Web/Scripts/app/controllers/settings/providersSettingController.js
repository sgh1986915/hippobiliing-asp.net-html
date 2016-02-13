app.controller("providersSettingController", ["$scope", "$window", "$timeout", "providerService", "practiceService", function ($scope, $window, $timeout,providerService, practiceService) {

    $scope.loaded = false;
    $scope.providers = [];
    $scope.IsNew = false;
    $scope.selectedProvider = {
    };
    $scope.selectedIndex = undefined;
    $scope.commandResult = {};
    $scope.keyword = '';
    $scope.availableUsers = [];

    //events
    $scope.$on("tabChanged", function (d, data) {
        $scope.commandResult = {};
        if (data === 'providers') {
            $scope.load();
        };
    });

    $scope.$on("lookupPopulate", function (d, prarm) {
        if (prarm.Tab == "providers") {
            practiceService.lookupNPI(prarm.NPI).then(function(data) {

                if (data.hasOwnProperty("NPI")) {
                    
                    $scope.selectedProvider.IndividualNPI = data.NPI;
                    $scope.selectedProvider.FullName = data.FullName;
                    $scope.selectedProvider.Degree = data.Degree;
                    $scope.selectedProvider.Address1 = data.Address1;
                    $scope.selectedProvider.Address2 = data.Address2;
                    $scope.selectedProvider.City = data.City;
                    $scope.selectedProvider.State = data.StateCode;
                    $scope.selectedProvider.ZipCode = data.ZipCode;
                    $scope.selectedProvider.Phone = data.PhoneNumber;
                    $scope.selectedProvider.Gender = data.Gender;
                    $scope.selectedProvider.Speciality = data.SpecialityId;
                    $scope.selectedProvider.LicenseNumber = data.LicenseNumber;
                    console.log(data.SpecialtyCode);
                    $scope.$emit("lookupCompleted", { Success: true });
                } else {
                    $scope.$emit("lookupCompleted", data);
                }
            }).then(function (data) {
                $timeout(function() {
                    $('#providers .selectpicker').selectpicker('refresh');
                }, 100);

            });
        }
    });

    //functions
    $scope.loadUsers = function(userId) {
        providerService.getAvailableUsers($scope.tab.Id, userId === undefined ? '' : userId).then(function(data) {
            if (data.hasOwnProperty('Success')) {
                $scope.commandResult = data;
            } else {
                $scope.availableUsers = data;
            }
           
        }).then(function (data) {
            //bootstrap-select
            $timeout(function () {
                $('#providers .selectpicker').selectpicker('refresh');
            }, 100);
        });
    };
    $scope.load = function () {
        providerService.searchProviders($scope.tab.Id, $scope.keyword).then(function (data) {
            $scope.providers = data;
            $scope.loaded = true;
        });
        
    };

    //actions
    $scope.create = function () {
        $scope.selectedProvider = {
            Gender: 0,
            SignatureOnFile: true,
            Active: true
        };
        $scope.loadUsers();
        $scope.IsNew = true;
    };
    $scope.edit = function (provider, index) {
        
        $scope.selectedProvider = angular.copy(provider);
        $scope.loadUsers(provider.UserId);
        $scope.selectedIndex = index;
        $scope.IsNew = false;
    };
    $scope.save = function () {
        
        $scope.selectedProvider.PracticeId = $scope.tab.Id;
        providerService.saveProvider($scope.selectedProvider).then(function (data) {
            if (data.hasOwnProperty('Success')) {
                $scope.commandResult = data;
            } else {
                $scope.selectedProvider = data;
                $scope.commandResult.Success = true;
                if ($scope.IsNew) {
                    $scope.providers.push(data);
                } else {
                    $scope.providers[$scope.selectedIndex] = data;
                }
            }
        });
    };
    $scope.back = function () {
        $scope.commandResult = {};
        $scope.selectedIndex = undefined;
        $scope.selectedProvider = {};
    };

    //watch
    $scope.$watch("keyword", function () {
        $scope.load();
    });
    $scope.$watch("selectedProvider.Phone", function(newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.selectedProvider.Phone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');
    });
    $scope.$watch("selectedProvider.ZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.selectedProvider.ZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });
}]);