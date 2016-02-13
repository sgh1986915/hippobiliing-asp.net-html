app.controller("authorizationController", ["$scope", "$window", "$timeout", "authorizationService", function ($scope, $window, $timeout, authorizationService) {
    $scope.authorizations = [];

    $scope.loadAuthorizations = function () {
        if (!$scope.tab) return;
        authorizationService.getAuthorizations($scope.tab.Id).then(function (data) {
            $scope.authorizations = data;
        });
    };

    $scope.select = function (authorization) {
        /*authorizationService.viewAuthorization(authorization.Id);

        $scope.append(angular.copy(authorization));*/
    };

    $scope.loadAuthorizations();
}]);