app.run([
    '$rootScope', function ($rootScope) {
        $rootScope.User = { UserName: getCookie("UserName") };
    }
]);

app.controller("appController", function($scope) {
    $scope.tab = {};
});

function getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) return parts.pop().split(";").shift();
};
