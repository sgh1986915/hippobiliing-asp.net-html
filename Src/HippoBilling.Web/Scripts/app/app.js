var app = angular.module("app", []);

app.directive('ngSelectChange', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        priority: 1, // needed for angular 1.2.x
        link: function (scope, elm, attr, selectCtrl) {
            if (attr.type === 'radio' || attr.type === 'checkbox') return;
            
            $(elm).bind('change', function () {
                
               scope.$apply(function () {
                   //var val = elm.val();
                   //switch (val) {
                   //    case '1':
                   //        val = false;
                   //        break;
                   //    case '0':
                   //         val = true;
                   //         break;
                   //     default:
                   //         val = val;
                   //         break;
                   //}
                   selectCtrl.$setViewValue(elm.val());
                });
            });
        }
    };
});

app.directive('ngDate', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        priority: 1, // needed for angular 1.2.x
        link: function (scope, elm, attr, selectCtrl) {
            if (attr.type === 'radio' || attr.type === 'checkbox') return;

            $(elm).bind('change', function () {

                scope.$apply(function () {
                    selectCtrl.$setViewValue(elm.val());
                });
            });
        }
    };
});

String.IsNullOrEmpty = function (value) {
    var isNullOrEmpty = true;
    if (value) {
        if (typeof (value) == 'string') {
            if (value.length > 0)
                isNullOrEmpty = false;
        }
    }
    return isNullOrEmpty;
};

String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
};