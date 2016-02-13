$(document).ready(function () {
    //$("#btn_edit,#createNote").click(function () {
    //    $("#edit1").hide();
    //    $("#edit2").show('slide', { direction: 'left' }, 500);
    //});

    //$("#btn_cancel").click(function () {
    //    $("#edit2").hide();
    //    $("#edit1").show('slide', { direction: 'left' }, 500);
    //});

    //$("#lib").click(function () {
    //    if (!$(this).hasClass('active')) {
    //        $(this).addClass('active');
    //    }
    //    $('#fav').removeClass('active');

    //    $("#favlist").hide();
    //    $("#liblist").show(100);
    //});

    //$("#fav").click(function () {
    //    if (!$(this).hasClass('active')) {
    //        $(this).addClass('active');
    //    }
    //    $('#lib').removeClass('active');

    //    $("#liblist").hide();
    //    $("#favlist").show(100);
    //});

    //$("#plib").click(function () {
    //    if (!$(this).hasClass('active')) {
    //        $(this).addClass('active');
    //    }
    //    $('#pfav').removeClass('active');

    //    $("#pfavlist").hide();
    //    $("#pliblist").show(100);
    //});

    //$("#pfav").click(function () {
    //    if (!$(this).hasClass('active')) {
    //        $(this).addClass('active');
    //    }
    //    $('#plib').removeClass('active');

    //    $("#pliblist").hide();
    //    $("#pfavlist").show(100);
    //});

    //$("#btnNewPayer").click(function () {
    //    $("#submitfrm").show();
    //    $("#btnCancel").hide();
    //    $("#pliblist").hide();
    //    $("#plibfrm").show('slide', { direction: 'down' }, 500);
    //});

    //$("#backlink").live("click", function (e) {
    //    e.preventDefault();

    //    $("#submitfrm").hide();
    //    $("#btnCancel").show();
    //    $("#plibfrm").hide();
    //    $("#pliblist").show('slide', { direction: 'down' }, 500);
    //});
    $(".datepicker:not(#dob)").datepicker({
        autoclose: true
    });
    var date = new Date();
  
    $("#dob").datepicker({
        autoclose: true,
        startDate: date.getMonth() + "/" + date.getDate() + "/" + (date.getFullYear() - 120),
        endDate: new Date()
    });
  
    $('.selectpicker').selectpicker();

});