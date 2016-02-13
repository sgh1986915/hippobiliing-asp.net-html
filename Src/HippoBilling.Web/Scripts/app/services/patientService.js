app.service("patientService", [
    "$q", "$http", function ($q, $http) {
        var service = {
            savePatient: function(patient) {
                var defer = $q.defer();
                $http.post("/patients/save-patient",patient)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post patients error");
                    });
                return defer.promise;
            },
            viewPatient: function (patientId) {
                var defer = $q.defer();
                $http.post("/patients/view-patient", { Id: patientId })
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post patients error");
                    });
                return defer.promise;
            },
            searchPatients: function (practiceId,keyword) {
                var defer = $q.defer();
                $http.get("/patients/search-patients?practiceId="+practiceId+"&keyword="+keyword)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get patients error");
                    });
                return defer.promise;
            },
            getViewedPatients: function (practiceId) {
                var defer = $q.defer();
                $http.get("/patients/get-viewed-patients?practiceId=" + practiceId)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get patients error");
                    });
                return defer.promise;
            },
            getCreatedPatients: function (practiceId) {
                var defer = $q.defer();
                $http.get("/patients/get-created-patients?practiceId=" + practiceId)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get patients error");
                    });
                return defer.promise;
            },
            getViewNotes: function(patientId,keyword,level) {
                var defer = $q.defer();
                $http.get("/patients/get-view-notes?patientId="+patientId+"&keyword="+keyword+"&level="+level)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("get view note error");
                    });
                return defer.promise;

            },
            saveViewNote: function(note) {
                var defer = $q.defer();
                $http.post("/patients/save-view-note", note)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post view note error");
                    });
                return defer.promise;

            },
            lookupPatients: function (practiceId, name, dob) {
                var defer = $q.defer();
                $http.get("/patients/lookup-patients?practiceId=" + practiceId + "&name=" + name + "&dateOfBirth=" + dob)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup patients error");
                    });
                return defer.promise;

                
            },
            searchLibraryPhysicians: function (keyword,state) {
                var defer = $q.defer();
                $http.get("/patients/search-library-physicians?keyword=" + keyword + "&state=" + state)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup physicians error");
                    });
                return defer.promise;


            },
            searchFavoritePhysicians: function (practiceId, keyword, state) {
                var defer = $q.defer();
                $http.get("/patients/search-favorite-physicians?practiceId=" + practiceId + "&keyword=" + keyword + "&state=" + state)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup physicians error");
                    });
                return defer.promise;


            },
            favoritePhysician: function (physician) {
                var defer = $q.defer();
                $http.post("/patients/favorite-physician", physician)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post physician error");
                    });
                return defer.promise;

            },
            searchLibraryPayers: function(keyword) {
                var defer = $q.defer();
                $http.get("/patients/search-library-payers?keyword=" + keyword)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup payers error");
                    });
                return defer.promise;
            },
            searchFavoritePayers: function(practiceId, keyword) {
                var defer = $q.defer();
                $http.get("/patients/search-favorite-payers?practiceId=" + practiceId + "&keyword=" + keyword)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup payers error");
                    });
                return defer.promise;
            },
            favoritePayer:function(practiceId, payerId) {
                var defer = $q.defer();
                $http.post("/patients/favorite-payer", {PracticeId:practiceId,PayerId:payerId})
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post payer error");
                    });
                return defer.promise;
            },
            savePayer: function(payer) {
                var defer = $q.defer();
                $http.post("/patients/save-payer", payer)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post payer error");
                    });
                return defer.promise;
            },
            getInsuranceGroups: function(patientId) {
                var defer = $q.defer();
                $http.get("/patients/get-insurances?patientId=" + patientId)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("lookup insurances error");
                    });
                return defer.promise;
            },
            transposeInsurance: function(sourceId, targetId) {
                var defer = $q.defer();
                $http.post("/patients/transpose-insurance", {SourceId:sourceId,TargetId:targetId})
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post insurance error");
                    });
                return defer.promise;
            },
            saveInsurance : function(insurance) {
                var defer = $q.defer();
                $http.post("/patients/save-insurance", insurance)
                    .success(function (data) {
                        defer.resolve(data);
                    }).error(function (data) {
                        console.log("post insurance error");
                    });
                return defer.promise;
            },
        };

        return service;
    }
]);