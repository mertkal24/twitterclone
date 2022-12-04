

$(document).ready(function () {
    $(".tweetle-button").click(function () {
        var postContent = $(".neler-oluyor").val();
        $.ajax({
            type: "Post",
            dataType: "Json",
            url: "/Post/PostAt",
            data: { 'postContent': postContent },
            success: function (msg) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Post Gönderildi',
                    showConfirmButton: false,
                    timer: 1500
                });
                setInterval(function () {
                    window.location.reload(false);
                }, 2000);
                window.location.href = msg;
            }

        });
    });
    $(".oneri-add-friend-item").click(function () {
        var istekGonderilecekUserId = this.getAttribute("id");
        $.ajax({
            type: "Post",
            dataType: "Json",
            url: "User/SendFriendRequest",
            data: { "istekGonderilecekUserId": istekGonderilecekUserId },
            success: function (msg) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'İstek Gönderildi',
                    showConfirmButton: false,
                    timer: 1500
                });
                setInterval(function () {
                    window.location.reload(false);
                }, 3000);
                $("#oneri-item-" + istekGonderilecekUserId).css("display", "none");
            }
        });
    });
    $(".cıkıs-yap").click(function () {
        $.ajax({
            type: "Post",
            url: "/Login/LogOut",
            dataType: "json",
            data: null,
            success: function (msg) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Çıkış Yapıldı',
                    showConfirmButton: false,
                    timer: 1500
                });
                setInterval(function () {
                    window.location.reload(false);
                }, 2000);
                window.location.href = msg;
                window.location.href = msg;
            }
        });
    });
    $(".comment-at").click(async function () {
       
        const { value: formValues } = await Swal.fire({
            title: 'Yorum Yap',
            html:
                '<input style="height:5rem" id="swal-input1" class="swal2-input">',                
            focusConfirm: false,
            preConfirm: () => {
                return [
                    document.getElementById('swal-input1').value,
                ]
            }
        })
        var id = this.getAttribute("id");
        
        var content = $("#swal-input1").val();
        if (formValues) {
            $.ajax({
                type: "Post",
                dataType: "Json",
                url: "/User/YorumAt",
                data: { "content": content, "id":id },
                success: function (msg) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Yorum Gönderildi',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    setInterval(function () {
                        window.location.reload(false);
                    }, 2000);
                }   
            });
        }
       
    });
    $('.search-input').keyup(function () {
        var length = $(".search-input").val().length;
        var searchText = $(".search-input").val();
        $(".result-list").empty();
        if (length > 2) {
            $.ajax({
                type: "Post",
                dataType: "Json",
                url: "/User/GetUserBySearchText",
                data: { "text": searchText },
                success: function (kisiler) {
                    $(".result-list").html();
                    for (var i = 0; i < kisiler.length; i++) {
                        
                        var resultDiv = kisiler[i].id + " " + kisiler[i].name + " " + kisiler[i].surname;
                        var row = "<div class=\"row search-result-item\" style=\"width: 100 %;\">";
                        var img = " <img class=\"rounded-circle img - fluid search-img\" src = \"" + kisiler[i].profilePicture + "\">";
                        var colmd3foto = "<div class=\"col-md-3\">";
                        var colmd9name = "<div class=\"col-md-9\" style=\"padding-left:30px\">";
                        var divEnd = "</div>";
                        var userNameSurname = "<b style=\"margin-left:1rem\">" + kisiler[i].name + " " + kisiler[i].surname + "</b>";
                        $(".result-list").append("<a href=\"/Profile/UserProfile/"+kisiler[i].id+"\"><span>" + row + img + userNameSurname + divEnd + "</span></a>");      
                    }
                }
            });
        }    
    }); 
    $(".accept-friend").click(function () {
        var id = this.getAttribute("id");

        $.ajax({
            type: "Post",
            dataType: "Json",
            url: "/User/AcceptFriend",
            data: { "id": id },
            success: function (msg) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Arkadaş Listene Eklendi',
                    showConfirmButton: false,
                    timer: 1500
                });
                setInterval(function () {
                    window.location.reload(false);
                }, 2000);
                window.location.href = msg;
            }


        });

    });
    $(".delete-friend").click(function () {
        var id = this.getAttribute("id");
        $.ajax({
            type: "Post",
            dataType: "Json",
            url: "/User/DeleteFriend",
            data: { "id": id },
            success: function (msg) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Arkadaşlıktan Çıkarma İşlemi Başarılı',
                    showConfirmButton: false,
                    timer: 1500
                });
                setInterval(function () {
                    window.location.reload(false);
                }, 3000);
                window.location.href = msg;
            }


        });

    });
});