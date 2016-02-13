app.controller("patientController", ["$scope", "$window","$timeout","patientService", function ($scope, $window,$timeout, patientService) {
    $scope.patients = [];
    $scope.selectedPatients = [];
    $scope.selectedRelations = [];
    $scope.selectedIndex = -1;
    $scope.viewedPatients = [];
    $scope.createdPatients = [];
    $scope.keyword = '';
    $scope.currentPatient = {};
    $scope.currentRelation = {};

    $scope.search = function() {
        if (!$scope.tab) return;
        patientService.searchPatients($scope.tab.Id, $scope.keyword).then(function(data) {
            $scope.patients = data;
            for (var i = 0; i < $scope.patients.length; i++) {
                $scope.patients[i].commandResult = {};
            }
        });
    };
    $scope.create = function () {
        var patient = {
            Name: "",
            Sex: 0,
            StatementHold: true,
            Active: true,
            StatementMethod: 0,
            Status:0
        };

        $scope.append(patient);
    };
    $scope.switchTab = function (index) {
        $scope.selectedIndex = index;
        if (index < 0) {
            $scope.currentPatient = {};
        } else {
            $scope.currentPatient = $scope.selectedPatients[index];
            $scope.currentRelation = $scope.selectedRelations[index];
            $scope.currentRelation.commandResult = {};
            $timeout(function () {
                $('.selectpicker').selectpicker('refresh');
            },10);
        }

        switch ($scope.currentRelation.currentTab.key) {
            case 'facesheet':
                $("#tab_patient_trigger_" + $scope.currentRelation.currentTab.subTab).click();
                break;
            default:
                    break;
        }

        $scope.$broadcast("patient.changed", '');
    };


    $scope.view = function(patient) {
        patientService.viewPatient(patient.Id);

        $scope.append(angular.copy(patient));
    };

    $scope.append = function(patient) {
        var index = -1;
   
        for (var i = 0; i < $scope.selectedPatients.length; i++) {
            if (angular.equals($scope.selectedPatients[i].Id,patient.Id)) {
                index = i;
                break;
            }
        }
        if (index < 0) {
            patient.commandResult = {};
            $scope.selectedPatients.push(patient);
            $scope.selectedRelations.push(newRelation());
            index = $scope.selectedPatients.length - 1;
        }
        $scope.switchTab(index);
    };

    $scope.save = function () {
        
        $scope.currentPatient.PracticeId = $scope.tab.Id;
        
       return patientService.savePatient($scope.currentPatient).then(function (data) {
            if (data.hasOwnProperty("Success")) {
                $scope.currentRelation.commandResult = data;
                return false;
            } else {
                refreshRecords($scope.patients, data, $scope.patients.length < 25);

                refreshRecords($scope.viewedPatients, data, true);
                if ($scope.viewedPatients.length > 5) {
                    $scope.viewedPatients(5, $scope.viewedPatients.length - 5);
                }

                $scope.viewedPatients.sort(function (a, b) {
                    a = new Date(a.LastViewedDate);
                    b = new Date(b.LastViewedDate);
                    return b-a;
                });

                refreshRecords($scope.createdPatients, data, true);
                if ($scope.createdPatients.length > 5) {
                    $scope.createdPatients(5, $scope.viewedPatients.length - 5);
                }

                $scope.createdPatients.sort(function (a, b) {
                    a = new Date(a.CreatedDate);
                    b = new Date(b.CreatedDate);
                    return b - a;
                });

                $scope.currentPatient = data;
                $scope.currentRelation.commandResult = { Success: true };
                $scope.selectedPatients[$scope.selectedIndex] = data;
                return true;
            }
        });
    };

    $scope.saveNew = function() {
        $scope.save().then(function (success) {
            if (success) {
                $scope.create();
            }
        });
    };

    $scope.viewNotes = function () {
        $scope.$broadcast("patient.viewNotes", $scope.currentRelation.patientNote);
    };
    $scope.lookupPatient = function() {
        $scope.$broadcast("patient.lookupPatient", '');
    };

    $scope.$on("lookupPatient.returned", function (d, data) {
        $scope.selectedPatients[$scope.selectedIndex] = data;
        $scope.currentPatient = data;
    });

    $scope.lookupPhysician = function () {
        $scope.$broadcast("patient.lookupPhysician", '');
    };

    $scope.$on("lookupPhysician.returned", function (d, data) {
        $scope.selectedPatients[$scope.selectedIndex].ReferringPhysicanNPI = data.NPI;
        $scope.selectedPatients[$scope.selectedIndex].ReferringPhysicanName = data.Name;
        $scope.currentPatient = $scope.selectedPatients[$scope.selectedIndex];
    });

    $scope.lookPayer = function() {
        $scope.$broadcast("insurance.lookupPayer", $scope.currentRelation.payer);
    };

    $scope.$on("lookupPayer.returned", function(d, data) {
        $scope.currentRelation.patientInsurance.currentInsurance.Payer = data;
        $scope.currentRelation.patientInsurance.currentInsurance.PayerId = data.Id;
    });

    $scope.loadViewedPatients = function () {
        if (!$scope.tab) return;
        patientService.getViewedPatients($scope.tab.Id).then(function(data) {
            $scope.viewedPatients = data;
        });
    };
    $scope.loadCreatedPatients = function () {
        if (!$scope.tab) return;
        if (!$scope.tab.hasOwnProperty("Id")) return;
        patientService.getCreatedPatients($scope.tab.Id).then(function (data) {
            $scope.createdPatients = data;
        });
    };

    $scope.loadViewedPatients();
    $scope.loadCreatedPatients();

    $scope.removeTab = function (index) {
       
        $scope.selectedPatients.splice(index, 1);
        $scope.selectedRelations.splice(index, 1);
        if ($scope.selectedIndex == index) {
            $scope.switchTab(-1);
        } else if ($scope.selectedIndex>index) {
            $scope.switchTab($scope.selectedIndex - 1);
        }
    };

    $scope.changeMethod = function(method) {
        $scope.currentPatient.StatementMethod = method;
    };

    function refreshRecords(array,entity,append) {
        var flag = false;
        for (var i = 0; i < array.length; i++) {
            if (angular.equals(array[i].Id, entity.Id)) {
                flag = true;
                array[i] = entity;
            }
        }
        if (!flag && append) {
            array.splice(0, 0, entity);
        }
    };


    $scope.$watch("keyword", function () {
        $scope.search();
    });
    $scope.$watch("currentPatient.PrimaryPhone", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.currentPatient.PrimaryPhone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

    });
    $scope.$watch("currentPatient.SecondaryPhone", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.currentPatient.SecondaryPhone = newVal.replace(/([0-9]{3})([0-9]{3})/g, '$1-$2-');

    });
    $scope.$watch("currentPatient.SSN", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.currentPatient.SSN = newVal.replace(/([0-9]{3})([0-9]{2})/g, '$1-$2-');
    });
    $scope.$watch("currentPatient.ZipCode", function (newVal, oldVal) {
        if (newVal === undefined || newVal === null) return;
        $scope.currentPatient.ZipCode = newVal.replace(/([0-9]{5})([0-9]{4})/g, '$1-$2');
    });


    function newRelation() {
        return {
            currentTab: { key: 'facesheet', subTab: 0 },
            commandResult: {},
            payer: {
                current: {},
                favoritePayers: [],
                libraryPayers: [],
                libraryKeyword: '',
                favoriteKeyword: '',
                tab: 'favorite'

            },
            patientInsurance: {
                loaded:false,
                groups: [],
                editing: false,
                currentGroup: {},
                currentInsurance: {}

            },
            patientNote: {
                notes: [],
                current: {}
            },
            patientSuperbill: {
                superbills: [],
                current: {}
            },
            patientFinancial: {
                financials: [],
                current: {}
            },
            patientDocument: {
                documents: [],
                current: {}
            },
            patientStatement: {
                statements: [],
                current: {}
            }
        };
    };


    $scope.switchPatientTab = function(tab) {
        $scope.currentRelation.currentTab.key = tab;
        console.log($scope.currentRelation.currentTab);
    };
    $scope.switchPatientSubTab = function(val) {
        $scope.currentRelation.currentTab.subTab = val;
        if ($scope.currentRelation.currentTab.key == 'facesheet' && val == 1) {
            loadInsurances(false);
        }
    };
    $scope.createInsurance = function (group) {

        $scope.currentRelation.patientInsurance.editing = true;
        $scope.currentRelation.patientInsurance.currentInsurance = { PatientId: $scope.currentPatient.Id, Payer: {}, Relationship: 0 };
        if (group) {
            $scope.currentRelation.patientInsurance.currentInsurance.PolicyType = group.GroupId;
        }
        $("#payModal").modal('show');
        $timeout(function() { $("#itab_0 .selectpicker").selectpicker('refresh'); }, 10);
        
        $scope.lookPayer();
    };
    $scope.selectGroup = function(group) {
        $scope.currentRelation.patientInsurance.editing = false;
        $scope.currentRelation.patientInsurance.currentGroup = group;

    };
    $scope.editInsurance = function(insurance) {
        $scope.currentRelation.patientInsurance.editing = true;
        $scope.currentRelation.patientInsurance.currentInsurance =angular.copy(insurance);
        $scope.currentRelation.patientInsurance.currentInsurance.commandResult = {};
        $timeout(function () { $("#itab_0 .selectpicker").selectpicker('refresh'); }, 10);
    };
    $scope.saveInsurance = function() {
        patientService.saveInsurance($scope.currentRelation.patientInsurance.currentInsurance).then(function (data) {
            if (!data.hasOwnProperty("Success")) {

                var group = { Insurances: [] };
                for (var i = 0; i < $scope.currentRelation.patientInsurance.groups.length; i++) {
                    if (angular.equals($scope.currentRelation.patientInsurance.groups[i].GroupId, data.PolicyType)) {
                        group = $scope.currentRelation.patientInsurance.groups[i];
                        break;
                    }
                }
                if (!group.hasOwnProperty('GroupId')) {
                    var changedPolicy = false;
                    for (var g = 0; g < $scope.currentRelation.patientInsurance.groups.length; g++) {
                        for (var ins = 0; ins < $scope.currentRelation.patientInsurance.groups[g].Insurances.length; ins++) {
                            if (angular.equals(data.Id, $scope.currentRelation.patientInsurance.groups[g].Insurances[ins].Id)) {
                                changedPolicy = true;
                                break;
                            }
                        }
                    }
                    if (changedPolicy) {
                        loadInsurances(true);
                    }
                    group = { GroupId: data.PolicyType, GroupName: data.PolicyTypeString, Insurances: [data] };
                    $scope.currentRelation.patientInsurance.groups.push(group);


                } else {

                    var existed = false;
                    for (var j = 0; j < group.Insurances.length; j++) {
                        if (angular.equals(group.Insurances[j].Id, data.Id)) {
                            group.Insurances[j] = data;
                            existed = true;
                            break;
                        }
                    }
                    if (!existed) {
                        group.Insurances.push(data);
                    }

                }
                $scope.currentRelation.patientInsurance.currentInsurance = data;
                $scope.currentRelation.patientInsurance.currentInsurance.commandResult = { Success: true };
            } else {
                $scope.currentRelation.patientInsurance.currentInsurance.commandResult = data;
            }
        });
    };
    $scope.cancelInsurance = function () {
        $scope.currentRelation.patientInsurance.editing = false;
        $scope.currentRelation.patientInsurance.currentInsurance = { PatientId: $scope.currentPatient.Id, Payer: {}, Relationship: 0 };
    };

    $scope.transposeInsurance = function(sourceIndex, targetIndex,group) {
        if (sourceIndex == targetIndex || sourceIndex < 0 || targetIndex < 0 || sourceIndex >= group.Insurances.length || targetIndex >= group.Insurances.length) return;
        var source = group.Insurances[sourceIndex];
        var target = group.Insurances[targetIndex];
        patientService.transposeInsurance(source.Id, target.Id).then(function(data) {
            if (data.Success === true) {
                var order = source.Order;
                source.Order = target.Order;
                target.Order = order;
                group.Insurances=group.Insurances.sort(function (a, b) {
                    return a.Order - b.Order;
               });
            }
        });
    };

    function loadInsurances(force) {
        if ((force||!$scope.currentRelation.patientInsurance.loaded)&&$scope.currentPatient.hasOwnProperty("Id")) {
            patientService.getInsuranceGroups($scope.currentPatient.Id).then(function(data) {
                $scope.currentRelation.patientInsurance.groups = data;
                $scope.currentRelation.patientInsurance.loaded = true;
                if (!$scope.currentRelation.patientInsurance.currentGroup.hasOwnProperty("GroupId") && data.length > 0) {
                    $scope.currentRelation.patientInsurance.currentGroup = data[0];
                }
            });
        }
    };

}]);