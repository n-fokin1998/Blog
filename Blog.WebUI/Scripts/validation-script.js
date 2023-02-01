$(function () {
    $("#Text").keyup(function() {
        if ($(this).val().length != 0) {
            $("input[type='submit']").removeAttr('disabled');
        }
        else {
            $("input[type='submit']").attr('disabled', 'disabled');
        }
    });
});