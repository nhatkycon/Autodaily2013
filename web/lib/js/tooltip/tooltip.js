
this.screenshotPreview = function () {
    xOffset = 10;
    yOffset = 30;
    $("a.tooltip").hover(function (e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "" + this.t : "<br/>";
        $("body").append("<div id='screenshot'><center><p style=\"color:#E97D13;margin:0;padding:0 0 5px 0;border-bottom:1px dotted #ccc;width=210px;margin-bottom:10px;\">" + c + "</p><img width=\"210px\" src='" + this.rel + "' alt='url preview' /></center></div>");
        $("#screenshot")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
    },
	function () {
	    this.title = this.t;
	    $("#screenshot").remove();
	});
	$("a.tooltip").mousemove(function (e) {
        $("#screenshot")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
};
$(document).ready(function () {
    screenshotPreview();
});