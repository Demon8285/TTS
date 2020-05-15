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
    var projectid = $(".myproject").attr("id");
    $.get("/Project/AddTask", { name: name, projectid: projectid }, function (data) {
        var newrow = `<tr>` +
            `<th><input class="form-control taskname text-center" type="text" value=${name} id=${data}</th>` +
            `<td><input class="form-control tasktime text-center" type="number" value=0 id=${data}</td>` +
            `<td><input type="checkbox" class="taskstatus" id=${data}</td>`+
            `<td><a class="btn btn-danger text-white" id=${data}>Видалить</a></td>` +
            `</tr>`;
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
var t = "dd {0}".format(1);
alert(t);