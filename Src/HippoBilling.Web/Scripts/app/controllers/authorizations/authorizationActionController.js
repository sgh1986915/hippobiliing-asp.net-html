app.controller("authorizationActionController", ["$scope", "$window", "$timeout", "authorizationService", function ($scope, $window, $timeout, authorizationService) {
    $scope.authorization = {};

    $scope.search = function () {
        if (!$scope.tab) return;
        authorizationService.searchPatients($scope.tab.Id, "").then(function (data) {
            $scope.patients = data;
            for (var i = 0; i < $scope.patients.length; i++) {
                $scope.patients[i].commandResult = {};
            }
        });
    };

    $scope.selectPatient = function (patient) {
        $scope.authorization.PatientName = patient.Name;
        $scope.authorization.PatientId = patient.Id;
        $('#patientModal').modal('hide');
    };

    $scope.save = function () {
        $scope.authorization.PracticeId = $scope.tab.Id;

        authorizationService.save($scope.authorization).then(function (data) {
            if (data.Redirect && data.Redirect != '') {
                $window.location.href = data.Redirect;
            } else {
                $scope.commandResult = data;
            }
        });
    };

    $scope.search();
}]);