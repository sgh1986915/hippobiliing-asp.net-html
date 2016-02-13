app.service("practiceService", [
    "$q", "$http", function ($q, $http) {
        var service = {};
        service.getPractice = function (id) {

            var defer = $q.defer();

            $http.get("/practices/get-practice?id="+id)
                .success(function(data) {
                    defer.resolve(data);
                }).error(function(data) {
                    console.log("get practice error");
                });
            return defer.promise;
        };

        service.save = function (practice) {
            var defer = $q.defer();
            $http.post("/practices/save-practice", practice).success(function (data) {
                defer.resolve(data);
            }).error(function(data) {
                console.log("post practice error");
            });
            return defer.promise;
        };

        service.getUserPractices = function(keyword) {
            var defer = $q.defer();
            $http.get("/practices/get-user-practices?keyword="+keyword).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("get user practices error");
            });
            return defer.promise;
        };

        service.selectPractice = function(practiceId) {
            var defer = $q.defer();
            $http.post("/practices/select-practice", { PracticeId: practiceId }).success(function(data) {
                defer.resolve(data);
            }).error(function(data) {
                console.log("select practice error");
            });
            return defer.promise;
        };

        service.createPractice = function() {
            var defer = $q.defer();
            $http.post("/practices/create-practice").success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("create practice error");
            });
            return defer.promise;
        };

        service.unSelectPractice = function(practiceId) {
            var defer = $q.defer();
            $http.post("/practices/unselect-practice", { PracticeId: practiceId }).success(function(data) {
                defer.resolve(data);
            }).error(function(data) {
                console.log("unselect practice error");
            });
            return defer.promise;
        };

        service.lookupNPI = function(npi) {
            var defer = $q.defer();
            $http.post("/practices/lookup-npi", { npi: npi }).success(function (data) {
                defer.resolve(data);
            }).error(function (data) {
                console.log("lookup npi error");
            });
            return defer.promise;
        };
        return service;
    }
]);