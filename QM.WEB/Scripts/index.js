var Index = (function () {
    var $given = $("#input-given");
    var $submit = $("#btn-submit");
    var $area = $("#area-result");

    $submit.on("click", getResult);

    function getResult() {
        var parameter = {
            given: $given.val()
        }
        Services.Home.GetResult(parameter, function (data) {
            $area.html(data);
        });
    }
})();