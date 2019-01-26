var Services = (function () {

    function customAJAX(ajax) {
        if (ajax.type == "POST") {
            ajax.data["__RequestVerificationToken"] = $('[name="__RequestVerificationToken"]').val();
        }

        let ajaxObj = {
            type: ajax.type || "GET",
            url: ajax.url,
            data: ajax.data,
            success: function (data) {
                if (ajax.fnCallback != null) {
                    ajax.fnCallback(data);
                }
            },
            error: function (error) {
                console.error(error)
            }
        }
        return $.ajax(ajaxObj)
    }

    function Home() {
        return {
            GetResult: function (data, fnCallback) {
                return customAJAX({
                    url: "../Home/GetResult",
                    data: data,
                    fnCallback: fnCallback
                })
            }
        }
    }

    return {
        Home: Home()
    }
})();