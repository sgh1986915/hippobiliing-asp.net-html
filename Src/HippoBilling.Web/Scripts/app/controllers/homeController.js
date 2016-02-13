app.controller("homeController", ["$scope", "$window", "practiceService", function ($scope, $window, practiceService) {
    $scope.loading = false;
    $scope.practices = [];
    $scope.keyword = '';
    $scope.allStatus = { All: -1, Inactive: 0, Active: 1 };
    $scope.commandResult = {};
    $scope.status = $scope.allStatus.All;
    $scope.source = [];

    $scope.load = function () {
        $scope.loading = true;
        practiceService.getUserPractices($scope.keyword).then(function(data) {
            $scope.practices = data;
            setSource();
            $scope.loading = false;
        });
    };

    $scope.select = function (practice) {
        if (!practice.ClickAble) return;

        practiceService.selectPractice(practice.Id).then(function(data) {
            if (data.Redirect && data.Redirect != '') {
                $window.location.href = data.Redirect;
            } else if(data.Success===false) {
                $("#warning").modal();
            }
        });

    };

    $scope.create = function() {
        practiceService.createPractice().then(function(data) {
            if (data.Redirect && data.Redirect != '') {
                $window.location.href = data.Redirect;
            } else if (data.Success === false) {
                $("#warning").modal();
            }
        });
    };


    $scope.switch = function (status) {
        $scope.status = status;
    };


    function setSource() {
        if ($scope.status == $scope.allStatus.Active) {
            sourceFilter(true);
        } else if ($scope.status == $scope.allStatus.Inactive) {
            sourceFilter(false);
        } else {
            $scope.source = angular.copy($scope.practices);
        }
    }

    function sourceFilter(active) {
        $scope.source = [];

        for (var i = 0; i < $scope.practices.length; i++) {
           
            if ($scope.practices[i].Active === active) {
                $scope.source.push(angular.copy($scope.practices[i]));
            }
        }
    }

    $scope.$watch("keyword", function () {
        $scope.load();
    });
    $scope.$watch("status", function () {
        setSource();
    });

    $scope.load();
}]);