$("#projectinput").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $(".card").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
$(".btn-secondary").click(function () {
    var id_t = $(this).attr("id");
    var card = $(this).parent().parent().parent();
    $.get("/Project/ProjectDelete", { id: id_t }, function (data) {
        card.remove();
    });
});