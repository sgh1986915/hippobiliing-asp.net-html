
app.controller("practiceSettingController", ["$scope", "$window", "practiceService", function($scope, $window, practiceService) {
    $scope.loaded = false;
    $scope.commandResult = {};
    $scope.practice = {
        Id: $scope.$parent.tab.Id,
        Name: $scope.$parent.tab.Name,
        IsNew: $scope.$parent.tab.IsNew,
        Active: true,
        BillingAddrSameAsMailingAddr: true,
        PaymentAddrSameAsMailingAddr: true,
        Speciality: '',
        MailingState: '',
        BillingState: '',
        PaymentState:''
    };

    $scope.$watch("practice.Speciality", function (newVal, oldVal) {

       
    });
    $scope.StatusOptions = [{ Text: "Active", Value: true }, { Text: "Inactive", Value: false }];
    $scope.switchBillingAddr = function(flag) {

        $scope.practice.BillingAddrSameAsMailingAddr = flag == 1;
    };

    $scope.switchPaymentAddr = function(flag) {
        $scope.practice.PaymentAddrSameAsMailingAddr = flag == 1;
    };


    $scope.$on("tabChanged", function (d, tab) {

        if (tab === 'general') {
            $scope.commandResult = {};
            if ($scope.loaded === false) {
                $scope.load();
            }
        }

    });

    $scope.$on("lookupPopulate", function(d, data) {
        
    });

    $scope.load = function() {
        if (!$scope.practice.IsNew) {
            practiceService.getPractice($scope.practice.Id).then(function (data) {
                $scope.practice = data;
                $scope.loaded = true;
            });
        } else {
            $scope.loaded = true;
        }
    };

    $scope.$watch("practice.Phone", function(newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.Phone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

    });
    $scope.$watch("practice.PhoneNo", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.PhoneNo = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

    });
    $scope.$watch("practice.FaxNo", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.FaxNo = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');
    });
    $scope.$watch("practice.MailingZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.MailingZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });
    $scope.$watch("practice.BillingZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.BillingZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });
    $scope.$watch("practice.PaymentZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.practice.PaymentZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });

    $scope.save = function () {
        $scope.practice.Id = $scope.$parent.tab.Id;
        $scope.practice.Name = $scope.$parent.tab.Name;
        $scope.practice.IsNew = $scope.$parent.tab.IsNew;
        practiceService.save($scope.practice).then(function (data) {
            if (data.Redirect && data.Redirect != '') {
                $window.location.href = data.Redirect;
            } else {
                $scope.commandResult = data;
            }
        });
    };


}]);