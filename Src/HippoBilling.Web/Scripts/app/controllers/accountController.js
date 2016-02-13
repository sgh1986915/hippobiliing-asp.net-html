accountApp.controller("accountController", ["$scope", "accountService", function ($scope, accountService) {

    $scope.model = {};
    $scope.ServerMessage = "";
    $scope.Loading = false;

    $scope.login = function () {

        $scope.ServerMessage = "";
        $scope.Loading = true;

        accountService.login($scope.model).then(function (result) {

            if (result.Success) {
                location.href = result.Redirect;
            } else {
                $scope.ServerMessage = result.Errors[0].Error;
                $scope.Loading = false;
            };
        });
    };

    $scope.forgotPassword = function() {

        $scope.ServerMessage = "";
        $scope.Loading = true;

        accountService.forgotPassword($scope.model).then(function (result) {

            if (result.Success) {
                location.href = result.Redirect;
            } else {
                $scope.ServerMessage = result.Errors[0].Error;
                $scope.Loading = false;
            };
        });
    };

}]);

accountApp.directive('ngLoadingbutton', function () {
    return {
        require: '?ngModel',
        restrict: 'A',
        link: function(scope, element) {
            if (element && element[0]) {
                var l = Ladda.create(element[0]);
                scope.$watch('Loading', function(newVal) {
                    if (newVal !== undefined) {
                        if (newVal)
                            l.start();
                        else
                            l.stop();
                    }
                });
            }
        }
    };
});

accountApp.directive('ngFocus', function ($timeout) {
    return {
        restrict: 'AC',
        link: function (scope, element) {
            $timeout(function () {
                element[0].focus();
            }, 0);
        }
    };
});