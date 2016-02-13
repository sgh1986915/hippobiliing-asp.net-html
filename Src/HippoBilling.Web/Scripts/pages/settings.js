$(document).ready(function () {

    $('.selectpicker').selectpicker();

    $('#settingModal').modal();


    $("#btnAddFee").click(function () {
        $("#feeList").hide();
        $("#feeAdd").show('slide', { direction: 'left' }, 500);
    });

    $("#feeAdd .backlink").live("click", function (e) {
        e.preventDefault();

        $("#feeAdd").hide();
        $("#feeList").show('slide', { direction: 'left' }, 500);
    });



    $("#locations").on("click", "#btnAddLocation,tbody tr", function() {
        $("#locationList").hide();
        $("#locationAdd").show('slide', { direction: 'left' }, 500);

    }).on("click", ".backlink,.cancelLocation", function(e) {
        e.preventDefault();
        $("#locationAdd").hide();
        $("#locationList").show('slide', { direction: 'left' }, 500);
    });


    $("#providers").on("click", ".backlink,.cancelProvider", function (e) {
        e.preventDefault();
        $("#providerAdd").hide();
        $("#providerList").show('slide', { direction: 'left' }, 500);
    }).on("click", "tbody tr,#btnAddProvider", function() {
        $("#providerList").hide();
        $("#providerAdd").show('slide', { direction: 'left' }, 500);
    });

    $("#users").on("click", "#activeUsersList tbody tr,#createUser", function () {
        $("#userList").hide();
        $("#userDetail").show('slide', { direction: 'left' }, 500);
    }).on("click", ".backlink,.cancelUser", function (e) {
        e.preventDefault();
        $("#userDetail").hide();
        $("#userList").show('slide', { direction: 'left' }, 500);
    });

});