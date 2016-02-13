app.controller("locationsSettingController", ["$scope", "$window", "$timeout", "locationService", "practiceService", function ($scope, $window, $timeout, locationService, practiceService) {

    $scope.loaded = false;
    $scope.locations = [];
    $scope.isNew = false;
    $scope.selectedLocation = {};
    $scope.selectedIndex = undefined;
    $scope.commandResult = {};
    $scope.keyword = '';

    //events
    $scope.$on("tabChanged", function (d, data) {
        $scope.commandResult = {};
        if (data === 'locations') {
            $scope.load();
        };

    });

    $scope.$on("lookupPopulate", function (d, prarm) {
        if (prarm.Tab == "locations") {
            practiceService.lookupNPI(prarm.NPI).then(function (data) {

                if (data.hasOwnProperty("NPI")) {

                    $scope.selectedLocation.NPI = data.NPI;
                    $scope.selectedLocation.InternalName = data.InternalName;
                    $scope.selectedLocation.Address1 = data.Address1;
                    $scope.selectedLocation.Address2 = data.Address2;
                    $scope.selectedLocation.City = data.City;
                    $scope.selectedLocation.State = data.StateCode;
                    $scope.selectedLocation.ZipCode = data.ZipCode;
                    $scope.selectedLocation.Phone = data.PhoneNumber;
                    $scope.$emit("lookupCompleted", { Success: true });
                } else {
                    $scope.$emit("lookupCompleted", data);
                }
            }).then(function (data) {
                $timeout(function() {
                    $('#locations .selectpicker').selectpicker('refresh');
                }, 100);

            });
        }
    });



    //functions

    $scope.load = function () {
        locationService.searchLocations($scope.tab.Id, $scope.keyword).then(function (data) {
            $scope.locations = data;
            $scope.loaded = true;
        });

    };

    //actions
    $scope.create = function () {

        $scope.selectedLocation = {Active:true};
        $scope.isNew = true;
        //bootstrap-select
        setTimeout(function () {
            $('#locations .selectpicker').selectpicker();

        }, 100);
    };
    $scope.edit = function (location, index) {
        $scope.selectedLocation = location;
        $scope.selectedIndex = index;
        $scope.isNew = false;
        //bootstrap-select
        $timeout(function () {
            $('#locations .selectpicker').selectpicker();

        }, 100);
    };
    $scope.save = function () {
        $scope.selectedLocation.PracticeId = $scope.tab.Id;
        locationService.saveLocation($scope.selectedLocation).then(function (data) {
            if (data.hasOwnProperty('Success')) {
                $scope.commandResult = data;
            } else {
                $scope.selectedLocation = data;
                $scope.commandResult.Success = true;
                if ($scope.isNew) {
                    $scope.locations.push(data);
                } else {
                    $scope.locations[$scope.selectedIndex] = data;
                }
            }
        });
    };
    $scope.back = function () {
        $scope.commandResult = {};
        $scope.selectedIndex = undefined;
        $scope.selectedLocation = {};
    };

    //watch
    $scope.$watch("keyword", function () {
        $scope.load();
    });
    $scope.$watch("selectedLocation.Phone", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.selectedLocation.Phone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');
    });
    $scope.$watch("selectedLocation.ZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.selectedLocation.ZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });
}]);