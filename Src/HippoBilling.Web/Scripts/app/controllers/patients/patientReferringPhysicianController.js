app.controller("patientReferringPhysicianController", [
    "$scope", "$window", "$timeout", "patientService", function($scope, $window, $timeout, patientService) {
    $scope.data = {
        keyword: '',
        state: 'TX',
        libraryKeyword: '',
        libraryState: '',
        favoriteKeyword: '',
        favoriteState: '',
        favoritePhysicians: [],
        libraryPhysicians: [],
        favorite: true
    };

    $scope.$on("patient.lookupPhysician", function(d, data) {

    });

    $scope.searchLibrary = function () {
        if (String.IsNullOrEmpty($scope.data.libraryKeyword) || String.IsNullOrEmpty($scope.data.libraryState)) return;
        patientService.searchLibraryPhysicians($scope.data.libraryKeyword, $scope.data.libraryState).then(function(data) {
            $scope.data.libraryPhysicians = data;
        });
    };
    $scope.searchFavorite = function() {
        if (String.IsNullOrEmpty($scope.data.favoriteState)||!$scope.tab) return;
        patientService.searchFavoritePhysicians($scope.tab.Id, $scope.data.favoriteKeyword, $scope.data.favoriteState).then(function (data) {
            $scope.data.favoritePhysicians = data;
        });
    };
    $scope.populate = function(physician) {
        $scope.$emit("lookupPhysician.returned", physician);
        $("#plModal").modal('hide');
    };

    $scope.favorite = function (physician) {
        if (!$scope.tab) return;
        physician.PracticeId = $scope.tab.Id;
        patientService.favoritePhysician(physician).then(function (data) {
            if (data.Success === true) {
                var existed = false;
                for (var i = 0; i< $scope.data.favoritePhysicians.length; i++) {
                    if (angular.equals($scope.data.favoritePhysicians[i].Id, physician.Id)) {
                        existed = true;
                        break;
                    }
                }
                if (!existed) {
                    $scope.data.favoritePhysicians.push(physician);
                }

            }
        });
    };

    $scope.switch = function(val) {
        $scope.data.favorite = val == 1;
        if ($scope.data.favorite) {
            $scope.data.favoriteKeyword = $scope.data.keyword;
            $scope.data.favoriteState = $scope.data.state;
        } else {
            $scope.data.libraryKeyword = $scope.data.keyword;
            $scope.data.libraryState = $scope.data.state;
        }
    };
    $scope.$watch("data.libraryKeyword", function() {
        $scope.searchLibrary();
    });
    $scope.$watch("data.libraryState", function() {
        $scope.searchLibrary();
    });
    $scope.$watch("data.favoriteKeyword", function() {
        $scope.searchFavorite();
    });
    $scope.$watch("data.favoriteState", function() {
        $scope.searchFavorite();
    });
    $scope.$watch("data.keyword", function () {
        if ($scope.data.favorite) {
            $scope.data.favoriteKeyword = $scope.data.keyword;
        } else {
            $scope.data.libraryKeyword = $scope.data.keyword;
        }
    });
    $scope.$watch("data.state", function () {
        if ($scope.data.favorite) {
            $scope.data.favoriteState = $scope.data.state;
        } else {
            $scope.data.libraryState = $scope.data.state;
        }
    });

}]);