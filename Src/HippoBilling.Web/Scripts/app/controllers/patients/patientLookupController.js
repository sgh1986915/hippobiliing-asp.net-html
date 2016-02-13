app.controller("patientLookupController", [
    "$scope", "$window", "$timeout", "patientService", function ($scope, $window, $timeout, patientService) {
        $scope.data = {name:'',dob:'',patients:[]};

        $scope.$on("patient.lookupPatient", function (d, data) {

        });
        $scope.$on("patient.changed", function (d, data) {
            $scope.data = { name: '', dob: '', patients: [] };
        });

        $scope.search = function () {
           
            if (!String.IsNullOrEmpty($scope.data.name) && !String.IsNullOrEmpty($scope.data.dob)&&$scope.tab) {
                patientService.lookupPatients($scope.tab.Id, $scope.data.name, $scope.data.dob).then(function (data) {
                    $scope.data.patients = data;
                });
            }
        };
        $scope.populate = function (patient) {
            $scope.$emit("lookupPatient.returned", patient);
            $("#lookupModal").modal('hide');
    };

        $scope.$watch("data.name", function () {
            $scope.search();
        });
        $scope.$watch("data.dob", function () {
            $scope.search();
        });

}]);