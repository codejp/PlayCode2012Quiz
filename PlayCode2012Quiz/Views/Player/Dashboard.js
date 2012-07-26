$(function () {
    var updateView = function(){
        $(".main-content").load("LatestDashboard");
    };
    setInterval(updateView, 3000);
});