$(document).ready(function () {
    getTodoList();
});

var Todo = {
    id: 0,
    whatIsTodo: ""
};

const url = "/api/Todos/";

function getTodoList() {
    $.ajax({
        url: url,
        type: 'GET',
        contentType: "application/json",
        dataType: 'json',
        success: function (todos) {
            todoListSuccess(todos);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function todoListSuccess(todos) {
    $("#todosTable tbody").remove();
    $.each(todos, function (i, todo) {
        todosAddRow(todo);
    });
}

function todosAddRow(todo) {
    if ($("#todosTable tbody").length === 0) {
        $("#todosTable").append("<tbody></tbody>");
    }

    $("#todosTable tbody").append(
        todosBuildTableRow(todo));
}

function todosBuildTableRow(todo) {
    var newRow = "<tr>" +
        "<td><input type='checkbox' /></td>" +
        "<td><input  class='input-name' type='text' value='" + todo.whatIsTodo + "'/></td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='todoUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + todo.id + "' " +
        "data-whatistodo='" + todo.whatIsTodo + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='todoDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + todo.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";

    return newRow;
}

function onAddTodo() {
    var options = {};
    options.url = url;
    options.type = "POST";
    var obj = Todo;
    obj.whatIsTodo = $("#whatistodo").val();
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";

    options.success = function (msg) {
        getTodoList();
        $("#whatistodo").val('');
        $("#msg").html(msg);
    },
        options.error = function () {
            $("#msg").html("Todo cannot be empty");
        };

    $.ajax(options);
}

function todoUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = url
        + id;
    options.type = "PUT";
    var obj = Todo;
    obj.id = $(item).data("id");
    obj.whatIsTodo = $(".input-name", $(item).parent().parent()).val();
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        $("#msg").html(msg);
    };
    options.error = function () {
        $("#msg").html("Todo cannot be empty");
    };
    $.ajax(options);
}

function todoDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = url + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        $("#msg").html(msg);
        getTodoList();
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON !== null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}