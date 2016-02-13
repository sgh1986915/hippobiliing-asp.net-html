var accountApp = angular.module("accountApp", []);

accountApp.service("accountService", [
    "$q", "$http", function($q, $http) {
        var service = {
            login: function(user) {
                var defer = $q.defer();
                $http.post("/account/login", user)
                    .success(function(data) {
                        defer.resolve(data);
                    }).error(function(data) {
                    console.log("login user error");
                });
                return defer.promise;
            },

            forgotPassword: function (email) {
                var defer = $q.defer();
                $http.post("/account/forgot-password", email)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("send email Verification error");
                    });
                return defer.promise;
            }
        };

        return service;
    }
]);