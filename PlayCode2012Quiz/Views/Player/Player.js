$(function () {

    $(".options input:radio").live("click", function () {
        var radio = $(this);
        $.post("/Player/SelectedOptionIndex", { "index": radio.val() });
    });

    var curstate = $("#currentstate");
    var updateView = function () {
        $.get("/Player/CurrentState", function (data) {
            if (parseInt(curstate.val()) != parseInt(data)) {
                $(".main-content").load("/Player/PlayerMainContent");
                curstate.val(data);
            }
        });
    };
    setInterval(updateView, 2000);
});