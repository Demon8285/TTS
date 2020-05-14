$(".btn-danger").click(function () {
    var id_t = $(this).attr("id");
    var tr = $(this).parent().parent();
    $.get("/Project/TaskDelete", { id: id_t }, function (data) {
        tr.remove();
    });
});
$(".taskname").on("change", function () {
    var value = $(this).val().toLowerCase();
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskName", { id: id_t, new_name: value }, function (data) {
        if (data) {
            alert("Ви змінили назву");
        }
    });
});
$("#taskinput").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("tbody tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
$(".btn-outline-success").click(function () {
    var name = $("#taskinput").val();
    $.get("/Project/AddTask", { name: name }, function (data) {
        var newrow = '<tr><th><input class="form-control addtask" type="text" value="' + name + '"id="' + data + '"/></th> <th>1</th>'+
            '<th><input type="checkbox" class="form-check" checked="checked" /></th>'+
            '<th><a class="btn btn-danger text-white" id="1sdds">Видалить</a></th></tr>'
        $("tbody").append(newrow);
    });
});
$(".tasktime").on("change", function () {
    var value = $(this).val().toLowerCase();
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskTime", { id: id_t, new_time: value }, function (data) {
        if (data) {
            alert("Ви змінили час");
        }
    });
});
$(".taskstatus").on("change", function (event) {
    var value = event.target.checked
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskStatus", { id: id_t, new_status: value }, function (data) {
        if (data) {
            alert("Ви змінили статус");
        }
    });
});