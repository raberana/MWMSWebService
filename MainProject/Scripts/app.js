(function ($) {

    $('#verifyBtn').click(function () {
        $.ajax({
            url: "/Home/Find",
            type: "POST",
            data: { userName: $('#txtUserName').val(), password: $('#txtPassword').val() },
            success: function (data) {
                var stringified = JSON.stringify(data);
                var returnedData = jQuery.parseJSON(stringified.substring(1, stringified.length - 1));
                if (returnedData.ClientId != null && returnedData.ClientId != "") {
                    $('#clientId').text(returnedData.ClientId);
                }
                else
                    $('#clientId').text("USER DOES NOT EXIST");
            }
        });
    });

})(jQuery);
