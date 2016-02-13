app.service("locationService", [
    "$q", "$http",function ($q, $http) {
        var service = {
            searchLocations: function (practiceId, keyword) {
                var defer = $q.defer();
                $http.get("/locations/search-locations?practiceId="+practiceId+"&keyword=" + keyword )
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get locations error");
                    });
                return defer.promise;
            },
            saveLocation: function (location) {
                var defer = $q.defer();
                $http.post("/locations/save-location",location)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post location error");
                    });
                return defer.promise;
            }
        };

        return service;
    }
]);