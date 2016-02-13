app.controller("practiceTabController", ["$scope", "$window", "practiceService", function ($scope, $window, practiceService) {
    $scope.practices = [];

    $scope.initTabs = function (tabs) {
        $scope.practices = tabs;
        for (var i = 0; i < $scope.practices.length; i++) {
            if ($scope.practices[i].Active) {
                $scope.$parent.tab = $scope.practices[i];
            }
        }
    };

    $scope.removeTab = function (practice, index) {
        if (practice.Active) {
            $scope.$parent.tab = {};
        }
        $scope.practices.splice(index, 1);
        practiceService.unSelectPractice(practice.Id);

    };

    $scope.switchTab = function (practice) {
        if (!practice.Active) {
            $window.location.href = practice.Url;
        }
    };


}]);