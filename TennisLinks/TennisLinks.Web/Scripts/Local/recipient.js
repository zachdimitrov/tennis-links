$(".write-message").click(function (e) {
    var userName = $(this).attr("href").split("=")[1];
    var current = $(this).attr("current");

    if (userName == current) {
        e.preventDefault();
        $("#error-message")
        .html("Sorry, <b>" + userName + "</b>, you cannot write message to youurself!")
        .removeClass("hidden")
        .show();

    } else {
        $("#error-message")
            .fadeOut()
            .addClass("hidden");;
    }
});

$(".message-to").change(function (e) {
    var recipient = e.target.value;

    $.ajax({
        method: "GET",
        url: "/home/getusers",
        data: {},
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            if (res.indexOf(recipient) < 0) {
                $("#error-message")
                .html("Sorry, no user <b>" + recipient + "</b> found!")
                .removeClass("hidden")
                .show();

                $(".send-button")
                    .attr("disabled", true);
            } else {
                $("#error-message")
                    .fadeOut()
                    .addClass("hidden");

                $("#recipient-name")
                    .html(recipient);

                $(".send-button")
                    .attr("disabled", false);
            }
        }
    })
});