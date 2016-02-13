app.controller("patientViewNoteController", [
    "$scope", "$window", "$timeout", "patientService", function ($scope, $window, $timeout, patientService) {
    $scope.data = {
       // notes:[]
    };
    $scope.$on("patient.viewNotes", function(d, data) {
        $scope.data = data;
        $scope.data.keyword = '';
        $scope.data.level = '';
        $scope.data.editing = false;
        $scope.load(false);
    });

    $scope.load = function(forced) {
        if ($scope.currentPatient.hasOwnProperty("Id")&&(forced || !$scope.data.hasOwnProperty("loaded") || $scope.data.loaded === false)) {
            patientService.getViewNotes($scope.currentPatient.Id, $scope.data.keyword, $scope.data.level).then(function(data) {
                if (!data.hasOwnProperty("Success")) {
                    $scope.data.notes = data;
                    $scope.data.loaded = true;
                };
            });
        }
    };
    $scope.create = function() {
        $scope.select({Level:0});
        $scope.edit(1);
    };
    $scope.save = function () {
        $scope.data.current.PatientId = $scope.currentPatient.Id;
        patientService.saveViewNote($scope.data.current).then(function (data) {
            var index = -1;
            for (var i = 0; i < $scope.data.notes.length; i++) {
                if (angular.equals($scope.data.notes[i].Id, data.Id)) {
                    index = i;
                    break;
                }
            }
            $scope.data.current =angular.copy(data);
            if (index > -1) {
                $scope.data.notes[i] = data;
            } else {
                
                $scope.data.notes.push(data);
            }
            $scope.edit(0);

        });
    };
    $scope.edit = function(editing) {
        $scope.data.editing = editing == 1;
    };
    $scope.select = function(note) {
        $scope.data.current = angular.copy(note);
    };
    $scope.changeLevel = function(level) {
        $scope.data.current.Level = level;
    };

    $scope.$watch("data.keyword", function() {
        $scope.load(true);
    });
    $scope.$watch("data.level", function () {
        $scope.load(true);
    });
}]);