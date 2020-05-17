$("table").on("click",".btn-danger",function () {
    var id_t = $(this).attr("id");
    var tr = $(this).parent().parent();
    $.get("/Project/TaskDelete", { id: id_t }, function (data) {
        tr.remove();
    });
});
$("table").on("change",".taskname", function () {
    var value = $(this).val().toLowerCase();
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskName", { id: id_t, new_name: value }, function (data) {
        if (data) {
            $(".toast").toast('show');
        }
    });
});
$("#taskinput").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("tbody tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
$("#taskbuttonadd").click(function () {
    var name = $("#taskinput").val();
    var projectid = $(".myproject").attr("id");
    $.get("/Project/AddTask", { name: name, projectid: projectid }, function (data) {
        if (data.success) {
            var newrow = `<tr>` +
                `<th><input class="form-control taskname text-center" type="text" value="${name}" id="${data.id}"</th>` +
                `<td><input class="form-control tasktime text-center" type="number" value="0" id="${data.id}"</td>` +
                `<td><input type="checkbox" class="taskstatus" id="${data.id}"</td>` +
                `<td><a class="btn btn-danger text-white" id="${data.id}">Видалить</a></td>` +
                `</tr>`;
            $("tbody").append(newrow);
        }
        else {
            alert(data.message);
        }
    });
});
$("table").on("change",".tasktime", function () {
    var value = $(this).val().toLowerCase();
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskTime", { id: id_t, new_time: value }, function (data) {
        if (data) {
            $(".toast").toast('show');
        }
    });
});
$("table").on("change",".taskstatus", function (event) {
    var value = event.target.checked
    var id_t = $(this).attr("id");
    $.get("/Project/UpdateTaskStatus", { id: id_t, new_status: value }, function (data) {
        if (data) {
            $(".toast").toast('show');
        }
    });
});