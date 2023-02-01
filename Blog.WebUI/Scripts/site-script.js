$(function () {
    $(".up").bind('click', function (e) {
        e.preventDefault();
        $('body,html').animate({ scrollTop: 0 }, 300);
    });
});
$(function () {
    $("input[name='Choise']").click(function (e) {
        $("#vote-submit").removeAttr("disabled");
    });
});