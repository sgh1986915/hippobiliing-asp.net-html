app.controller("insurancePayerController", [
    "$scope", "$window", "$timeout", "patientService", function ($scope, $window, $timeout, patientService) {
        $scope.data = {
            loaded: false,
            payerTab:'favorite'
        };
        $scope.$on("insurance.lookupPayer", function (d, data) {
            $scope.data = data;

        });

        $scope.searchLibrary = function () {
            patientService.searchLibraryPayers($scope.data.libraryKeyword).then(function (data) {
                $scope.data.libraryPayers = data;
            });
        };
        $scope.searchFavorite = function () {
            if (!$scope.tab) return;
            patientService.searchFavoritePayers($scope.tab.Id, $scope.data.favoriteKeyword).then(function (data) {
                $scope.data.favoritePayers = data;
            });
        };

        $scope.save = function() {
            patientService.savePayer($scope.data.currentPayer).then(function (data) {
                if (!data.hasOwnProperty('Success')) {
                    var existed = false;
                    for (var i = 0; i < $scope.data.libraryPayers.length; i++) {
                        if (angular.equals($scope.data.libraryPayers[i].Id, data.Id)) {
                            existed = true;
                            $scope.data.libraryPayers[i] = data;
                            break;
                        }
                    }
                    if (!existed) {
                        $scope.data.libraryPayers.push(data);
                    }
                    $scope.data.currentPayer.commandResult = {Success:true};
                    
                } else {
                    $scope.data.currentPayer.commandResult=data;
                }
             
            });
        };

        $scope.favorite = function (payer) {
            if (!$scope.tab) return;
            patientService.favoritePayer($scope.tab.Id,payer.Id).then(function (data) {
                if (data.Success === true) {
                    var existed = false;
                    for (var i = 0; i < $scope.data.favoritePayers.length; i++) {
                        if (angular.equals($scope.data.favoritePayers[i].Id, payer.Id)) {
                            existed = true;
                            break;
                        }
                    }
                    if (!existed) {
                        $scope.data.favoritePayers.push(payer);
                    }

                }
            });
        };
        $scope.edit = function(payer) {
            $scope.data.currentPayer = angular.copy(payer);
            $scope.data.currentPayer.commandResult = {};
            $scope.data.tab = 'payer';
        };

        $scope.$watch("data.libraryKeyword", function (newVal) {
            $scope.searchLibrary();
        });

        $scope.$watch("data.favoriteKeyword", function (newVal) {
            $scope.searchFavorite();
        });

        $scope.switchPayerTab = function (tab) {
        
            $scope.data.tab = tab;
        };

        $scope.select = function(payer) {
            $scope.$emit("lookupPayer.returned", payer);
            $("#payModal").modal('hide');
          
        };

        $scope.$watch("data.currentPayer.Phone", function (newVal, oldVal) {
            if (newVal === undefined || newVal === null) return;
            $scope.data.currentPayer.Phone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

        });
        $scope.$watch("data.currentPayer.Fax", function (newVal, oldVal) {
            if (newVal === undefined || newVal === null) return;
            $scope.data.currentPayer.Fax = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

        });
        $scope.$watch("data.currentPayer.ZipCode", function (newVal, oldVal) {
            if (newVal === undefined || newVal === null) return;
            $scope.data.currentPayer.ZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
        });
        $scope.$watch("data.currentPayer.State", function (newVal, oldVal) {
            $timeout(function() {
                $("#payModal .selectpicker").selectpicker('refresh');
            }, 10);
        });

}]);