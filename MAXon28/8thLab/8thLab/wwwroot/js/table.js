window.onload = init;
var lastId = 0;
var currentId;
var currentAction = "";

function init() {
    lastId = $(".table tr:last").attr("id");
    console.log($(".table tr:last").attr("id"));
};

function AddClick() {
    currentAction = "Add";
    $("#name").val("");
    $("#model").val("");
    $("#price").val("");
    $(".editContainer").fadeIn();
}

function EditClick(id) {
    currentAction = "Edit";
    $(".editContainer").fadeIn();
    currentId = id;
    $("#name").val($(`#name-${id}`).html());
    $("#model").val($(`#model-${id}`).html());
    $("#price").val(parseInt($(`#price-${id}`).html().split(" ₽")[0]));
}

function DeleteClick(id) {
    var name = $(`#name-${id}`).html();
    var model = $(`#model-${id}`).html();
    $(`#${id}`).remove();
    $.ajax({
        type: "POST",
        url: "/EighthLab/DeleteCar",
        data: { name, model },
        dataType: ""
    });
}

function SaveClick() {
    console.log(currentAction);
    var name = $("#name").val();
    var model = $("#model").val();
    var price = $("#price").val();
    if (currentAction == "Add") {
        $.ajax({
            type: "POST",
            url: "/EighthLab/AddCar",
            data: { name, model, price },
            dataType: ""
        });
        lastId = parseInt(lastId) + parseInt(1);; 
        console.log(lastId.toString());
        $(".table").append(`<tr id="${lastId}">
                                <td id="name-${lastId}" class="text-center">${name}</td>
                                <td id="model-${lastId}" class="text-center">${model}</td>
                                <td id="price-${lastId}" class="text-center">${price} ₽</td>
                                <td class="text-center">
                                    <button style="color: cyan;" onclick="EditClick(${lastId})">Изменить</button>
                                    <button style="color: coral;" onclick="DeleteClick(${lastId})">Удалить</button>
                                </td>
                            </tr>`);
        $(".editContainer").fadeOut();
    }
    else {
        $.ajax({
            type: "POST",
            url: "/EighthLab/EditCar",
            data: { name, model, price },
            dataType: ""
        });
        $(`#name-${currentId}`).html(name);
        $(`#model-${currentId}`).html(model);
        $(`#price-${currentId}`).html(price + " ₽");
        $(".editContainer").fadeOut();
        currentId = -1;
    }
}