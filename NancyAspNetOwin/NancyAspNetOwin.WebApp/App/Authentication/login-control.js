define(["jquery", "knockout", "bootstrap"], function ($, ko) {
    function loginControl(params) {
        var self = this;

        self.userName = ko.observable("testuser");
        self.password = ko.observable("testuser");

        self.getToken = function () {
            var request = ko.toJSON(self);

            $.ajax({
                url: "/login",
                type: "POST",
                data: request,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $.ajaxSetup({
                        'beforeSend': function (xhr) {
                            xhr.setRequestHeader('Authorization', result);
                        }
                    });
                    params.data(result);
                    params.bus.notifySubscribers({}, "logged-in");
                    $("#loginForm").modal("hide");
                }
            });
        };
    };

    return loginControl;
});
