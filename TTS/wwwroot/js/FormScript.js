function load() {
    var li = $(".errors_box").find("ul").find("li");
    var x = li.css('display')
    if (li.length > 0 && x != "none") {
        $(".errors_box").show();
    }
}
load();
$("#button_close").click(function () {
    $(".errors_box").remove();
});