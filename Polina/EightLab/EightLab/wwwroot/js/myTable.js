window.onload = init;
var lastId = 0;
var currentId;
var action = "";

function init() {
    lastId = $(".table tr:last").attr("id");
};

function AddClick() {
    action = "Add";
    $("#name").val("");
    $("#manufacturer").val("");
    $("#filling").val("");
    $(".edit").fadeIn();
}

function EditClick(id) {
    action = "Edit";
    $(".edit").fadeIn();
    currentId = id;
    $("#name").val($(`#name-${id}`).html());
    $("#manufacturer").val($(`#manufacturer-${id}`).html());
    $("#filling").val($(`#filling-${id}`).html());
}

function DeleteClick(id) {
    var name = $(`#name-${id}`).html();
    var manufacturer = $(`#manufacturer-${id}`).html();
    $(`#${id}`).remove();
    $.ajax({
        type: "POST",
        url: "/MySite/DeleteBread",
        data: { name, manufacturer },
        dataType: ""
    });
}

function SaveClick() {
    var name = $("#name").val();
    var manufacturer = $("#manufacturer").val();
    var filling = $("#filling").val();
    if (action == "Add") {
        $.ajax({
            type: "POST",
            url: "/MySite/AddBread",
            data: { name, manufacturer, filling },
            dataType: ""
        });
        lastId = parseInt(lastId) + parseInt(1);;
        $(".table").append(`<tr id="${lastId}">
                                <td id="name-${lastId}" class="text-center">${name}</td>
                                <td id="manufacturer-${lastId}" class="text-center">${manufacturer}</td>
                                <td id="filling-${lastId}" class="text-center">${filling}</td>
                                <td class="text-center">
                                    <button style="color: blue;" onclick="EditClick(${lastId})">Изменить</button>
                                    <button style="color: red;" onclick="DeleteClick(${lastId})">Удалить</button>
                                </td>
                            </tr>`);
        $(".edit").fadeOut();
    }
    else {
        $.ajax({
            type: "POST",
            url: "/MySite/EditBread",
            data: { name, manufacturer, filling },
            dataType: ""
        });
        $(`#name-${currentId}`).html(name);
        $(`#manufacturer-${currentId}`).html(manufacturer);
        $(`#filling-${currentId}`).html(filling);
        $(".edit").fadeOut();
        currentId = -1;
    }
}