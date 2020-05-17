function load() {
    var er_box = $(".errors_box");
    if (er_box.children().length > 1) {
        er_box.show();
    }
}
load();
$("#button_close").click(function () {
    $(".errors_box").remove();
});