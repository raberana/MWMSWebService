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



//app.factory('productFactory', function () {
//    var factory = {};
//    var status = "";
//    var products = [];
//    factory.getProducts = function () {
//        $.getJSON('Api/Product', function (_products) {
//            var datas = angular.toJson(_products, true)
//            $.each(datas, function (key, data) {
//                products.push(data);
//            });

//        }).fail(function (xhr, textStatus, err) {
//            alert("error show");
//            return;
//        });
//        return products;
//    };
//    factory.getProductById = function (id) {
//        $.getJSON('Api/Product/' + id, function (product) {
//            products = [];
//            products.push(product);
//        }).fail(function (xhr, textStatus, err) {
//            status = err;
//        });
//    };
//    return factory;
//});