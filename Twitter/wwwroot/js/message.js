$(document).ready(function () {
    var userConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub/").build();
    document.getElementsByClassName("msg_send_btn").disabled = true;
    userConnection.on("ReceiveMessage", function (message) {
        var anaDiv = "<div style=\"margin-bottom:5px;\" class=\"incoming_msg\">";
        var imgDiv = "<div class=\"incoming_msg_img\">" + "<img src=\"https://ptetutorials.com/images/user-profile.png\" alt=\"sunil\"> </div>";
        var received_msg = "<div class=\"received_msg\">" + " <div class=\"received_withd_msg\">" + "<p>" + message + "</p>" + "</div></div></div>";
        var result = String(anaDiv) + String(imgDiv) + String(received_msg);
        $("#hist").append(String(result));


    });
    userConnection.start().then(function () {
        document.getElementsByClassName("msg_send_btn").disabled = false;
    }).catch(function (err) {
        return console.log(err.toString());
    });;
    $(".chat_people").on("click", function (event) {
        $(".msg_history").html(" ");
        $(".mesgs").css("display", "block");
        mesajAtilacakKisiId = this.getAttribute("id");
        var mesajAtanKisiId = $(".autUser").attr("id");
        var roomname = Number(mesajAtanKisiId) + Number(mesajAtilacakKisiId);
        var room = String(roomname);
        userConnection.invoke("JoinGroup", room).catch(function (err) {
            return console.log(err.toString());
        });
       
        event.preventDefault();
    });

    $(".msg_send_btn").on("click", function (event) {
        mesajAtilacakKisiId = $(".chat_people").attr("id");
        var mesajAtanKisiId = $(".autUser").attr("id");
        var roomname = Number(mesajAtanKisiId) + Number(mesajAtilacakKisiId);
        var usertext = $(".write_msg").val();
        var userName = $(".autUser").html();
        var room = String(roomname);
        userConnection.invoke("SendMessagetoGroup", usertext, userName, room).catch(function (err) {
            return console.log(err.toString());
        });

        event.preventDefault();
    });

})
