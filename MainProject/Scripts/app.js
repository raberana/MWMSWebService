(function ($) {

	$('#verifyBtn').click(function () {

		$.ajax({
			url: "/Home/Find",
			type: "POST",
			data: { userName: $('#txtUserName').val(), password: $('#txtPassword').val() },
			success: function (data) {
				alert(JSON.stringify(data));
				var returnedData = jQuery.parseJSON((JSON.stringify(data)));
				if (returnedData.ClientId != null && returnedData.ClientId != "")
				{
					alert(returnedData.ClientId);
				}
				
				
			}
		});

	});

})(jQuery);
