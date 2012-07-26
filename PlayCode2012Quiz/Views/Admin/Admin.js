$(function () {
    var updateViewState = function () {
        var currentStateVal = parseInt($("#currentState").val());
        if (currentStateVal != 0)
            $("#currentQuestion").attr("disabled", "disabled");
        else
            $("#currentQuestion").removeAttr("disabled");
    };

    updateViewState();

    $("#currentState").live("change", function () {
        $.post("/Admin/CurrentState", { "state": $(this).val() });
        updateViewState();
    });

    $("#currentQuestion").live("change", function () {
        $.post(
            "/Admin/CurrentQuestion",
            { "questionID": $(this).val() },
            function () {
                $(".question-body").load("/Admin/QuestionBody");
            });
    });
});