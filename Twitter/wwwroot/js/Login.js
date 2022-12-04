$(document).ready(function () {
    $(".giris-yap").click(function () {
        var user = {
            Email: $("#Email").val(),
            Password: $("#Password").val()
        };
        $.ajax({
            type: "Post",
            url: "/Login/Index",
            datatype: "json",
            data: user,
            success: function (msg) {
                if (msg == "1") {
                    alert("Hatalı Kullanıcı Adı Veya Şifre");
                    window.location.href = "Url.Action('Index','Login')";
                }
                else {
                    window.location.href = msg;
                }
            }


        });

    });


});