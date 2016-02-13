app.service("authorizationService", [
    "$q", "$http",function ($q, $http) {
        var service = {
            searchPatients: function (practiceId, keyword) {
                var defer = $q.defer();
                $http.get("/patients/search-patients?practiceId=" + practiceId + "&keyword=" + keyword)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get patients error");
                    });
                return defer.promise;
            },
            save: function (authorization) {
                var defer = $q.defer();
                $http.post("/authorizations/save-authorization", authorization).success(function (data) {
                    defer.resolve(data);
                }).error(function (data) {
                    console.log("post authorization error");
                });
                return defer.promise;
            },
            getAuthorizations: function (practiceId) {
                var defer = $q.defer();
                $http.get("/authorizations/get-authorizations?practiceId=" + practiceId).success(function (data) {
                    defer.resolve(data);
                }).error(function (data) {
                    console.log("get authorizations error");
                });
                return defer.promise;
            }
        };

        return service;
    }
]);