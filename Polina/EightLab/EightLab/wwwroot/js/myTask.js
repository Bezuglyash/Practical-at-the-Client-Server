window.onload = init;

function init() {
};

function TaskClick() {
    var str = $("#str").val();
    if (str != "") {
        $.ajax({
            type: "POST",
            url: "/MySite/GetCountRepeatSymbols",
            data: { str },
            dataType: "text",
            success: function (answer) {
                $("#divAnswer").css("display", "flex");
                $("#answer").text(answer);
            },
            error: function (req, status, error) {
                alert(error);
            }
        });
    }
}