app.controller("settingsController", [
    "$scope", "$window", "$timeout", "practiceService", function ($scope, $window, $timeout, practiceService) {

    $scope.currentTab = "general";
    $scope.npi = '';
    $scope.commandResult = {};
    $scope.switchTab = function (tab) {
        $scope.currentTab = tab;
        $scope.npi = '';
        $scope.commandResult = {};
        $scope.npiForm.$setPristine();

        $scope.$broadcast("tabChanged", $scope.currentTab);
    };
    $scope.$on("usersChanged", function(d, data) {
        $scope.$broadcast("usersChanged", data);
    });

    $scope.$on("lookupCompleted", function (d, data) {
        if (data.Success === true) {
            $("#npiModal").modal("hide");
            $scope.npiForm.$setPristine();
        } else {
            $scope.commandResult = data;
        }

    });

    //$timeout(function () {
    //    $scope.$broadcast('tabChanged', 'general');
        //}, 500);

    $scope.lookup = function () {
        $scope.$broadcast("lookupPopulate", { Tab: $scope.currentTab, NPI: $scope.npi });

    };

    $scope.$watch("npi", function() {
        $scope.commandResult = {};
    });
}]);