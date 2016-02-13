app.service("userService", [
    "$q", "$http", function ($q, $http) {
        var service = {};

        service.get = function (id) {

            var defer = $q.defer();

            $http.get("/users/get-user?id=" + id)
                .success(function (data) {
                    defer.resolve(data);
                }).error(function (data) {
                    console.log("get user error");
                });
            return defer.promise;
        };

        service.getUsers = function (practiceId, keyword, active) {
            var defer = $q.defer();
            $http.get("/users/get-users?practiceId="+practiceId+"&keyword=" + keyword+"&active="+active)
                .success(function (data) {
                    defer.resolve(data);
                }).error(function (data) {
                    console.log("get users error");
                });
            return defer.promise;
        }

        service.save = function (user) {
            var defer = $q.defer();
            $http.post("/users/save-user", user).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("post user error");
            });
            return defer.promise;
        };

        service.create = function (user) {
            var defer = $q.defer();
            $http.post("/users/create-user", user).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("post user error");
            });
            return defer.promise;
        };

        service.activeUsers = function (ids) {
            var defer = $q.defer();
            $http.post("/users/active-users", {UserIds:ids }).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("post user error");
            });
            return defer.promise;
        };

        service.getPermissions = function(practiceId,userId) {
            var defer = $q.defer();
            $http.get("/users/get-permissions?practiceId="+practiceId+"&userId="+userId).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("get user permissions error");
            });
            return defer.promise;
        };

        service.savePermissions = function(practiceId,userId,permissions) {
            var defer = $q.defer();
            $http.post("/users/save-permissions", { PracticeId: practiceId, UserId: userId, UserPermissions: permissions }).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("post user permissions error");
            });
            return defer.promise;
        };

        return service;
    }
]);