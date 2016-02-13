app.controller("usersSettingController", [
    "$scope", "userService", function($scope, userService) {
        $scope.activeUsersList = [];
        $scope.selectedUser = {};
        $scope.inactiveUsersList = [];
        $scope.active = true;
        $scope.activeKeyword = '';
        $scope.inactiveKeyword = '';
        $scope.activeUserCount = 0;
        $scope.inactiveUserCount = 0;
        $scope.pendingActiveIds = [];
        $scope.commandResult = {};
        $scope.inDetail = true;
        $scope.permissions = [];


    function refreshUsers(active) {
        if (active === false) {

            userService.getUsers($scope.tab.Id, $scope.inactiveKeyword, false).then(function(data) {
                $scope.inactiveUsersList = data;
                $scope.inactiveUserCount = data.length;
            });
        } else {

            userService.getUsers($scope.tab.Id, $scope.activeKeyword, true).then(function(data) {
                $scope.activeUsersList = data;
                $scope.activeUserCount = data.length;
            });
        }
    }


    $scope.init = function() {
        userService.getUsers($scope.tab.Id, $scope.activeKeyword, $scope.active).then(function (data) {
            $scope.activeUsersList = data;
            $scope.activeUserCount = data.length;
        });
    };
    $scope.$watch("active", function (newVal,oldVal) {
        if (newVal === undefined || newVal === null) return;
        refreshUsers(newVal);
    });
    $scope.$watch("activeKeyword", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        refreshUsers(true);
    });
    $scope.$watch("inactiveKeyword", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;

        refreshUsers(false);

    });

    $scope.inactiveUserChange = function (user) {
        var index = $scope.pendingActiveIds.indexOf(user.Id);
      
            if (index < 0) {
                user.Active = true;
                $scope.pendingActiveIds.push(user.Id);
            } else {
                user.Active = false;
                $scope.pendingActiveIds.splice(index, 1);
            }
        
    };

    $scope.editUser = function (user) {
        $scope.selectedUser =angular.copy(user);
    };

    $scope.createUser = function () {
        $scope.selectedUser = {Active:true};
    };

    $scope.back = function () {
        refreshUsers(true);
        $scope.inDetail = true;
        $scope.active = true;
        $scope.commandResult = {};
    };

    $scope.swithList = function (flag) {
        $scope.active = flag == 1;
    };

    $scope.swithDetail = function (flag) {
        $scope.inDetail = flag == 1;
        $scope.commandResult = {};
        if (flag == 0) {
            $scope.getPermissions();
        }
    };
  
    $scope.activeUsers = function () {
        
        userService.activeUsers($scope.pendingActiveIds).then(function (result) {
            if (result.Success === true) {
                 refreshUsers(false);
            }
        });
    }

    $scope.saveUser = function () {
        $scope.selectedUser.PracticeId = $scope.tab.Id;
        if ($scope.selectedUser.Id) {
            userService.save($scope.selectedUser).then(function(data) {
                $scope.commandResult = data;
                //$scope.$emit("usersChanged", "udpate");
            });
        } else {
            userService.create($scope.selectedUser).then(function(data) {
                if (!data.hasOwnProperty('Success')) {
                    $scope.selectedUser = data;
                    $scope.commandResult.Success = true;
                } else {
                    $scope.commandResult = data;
                }
                //$scope.$emit("usersChanged", "create");
            });
        }
    };

    $scope.getPermissions = function() {
        userService.getPermissions($scope.$parent.tab.Id, $scope.selectedUser.Id).then(function(data) {
            $scope.permissions = data;
        });
    };

    $scope.setPermission = function (p, l) {
        p[l] = !p[l];
    };

    $scope.savePermissions = function () {
        userService.savePermissions($scope.$parent.tab.Id, $scope.selectedUser.Id, $scope.permissions).then(function (data) {
            $scope.commandResult = data;
        });
    };
}]);