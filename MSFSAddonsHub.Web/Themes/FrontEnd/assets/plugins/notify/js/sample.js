// Generated by CoffeeScript 2.1.0
(function (e) {
  $(function (e) {
    $.growl({
      title: "Growl",
      message: "Hi I'm Templist"
    });

	$(document).on("click", ".error", function (event) {
      event.preventDefault();
      event.stopPropagation();
      return $.growl.error({
        message: "please check Your details ...file is missing"
      });
    });
    $(document).on("click",".notice", function (event) {
      event.preventDefault();
      event.stopPropagation();
      return $.growl.notice({
        message: "You have 4 notification"
      });
    });
    return $(document).on("click", ".warning", function (event) {
      event.preventDefault();
      event.stopPropagation();
      return $.growl.warning({
        message: "read all details carefully"
      });
    });
  });
}).call(this);