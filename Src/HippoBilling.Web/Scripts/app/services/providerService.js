app.service("providerService", [
    "$q", "$http", function ($q, $http) {
        var service = {
            searchProviders: function(practiceId, keyword) {
                var defer = $q.defer();
                $http.get("/providers/search-providers?practiceId="+practiceId+"&keyword=" + keyword)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("search providers error");
                    });
                return defer.promise;
            },
            saveProvider: function(provider) {
                var defer = $q.defer();
                $http.post("/providers/save-provider",provider)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("save provider error");
                    });
                return defer.promise;
            },
            getAvailableUsers: function (practiceId,userId) {
                var defer = $q.defer();
                $http.get("/providers/get-available-users?practiceId="+practiceId+"&userId="+userId)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get users error");
                    });
                return defer.promise;
            }
        };

        return service;
    }
]);