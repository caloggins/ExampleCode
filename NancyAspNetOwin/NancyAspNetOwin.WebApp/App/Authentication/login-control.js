define(["jquery", "knockout"], function ($, ko) {
    function loginControl(params) {
        var self = this;

        self.showLoginControls = ko.observable(true);

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
                    self.showLoginControls(false);
                    window.sessionStorage.setItem("token", result);
                }
            });
        };
    };

    return loginControl;
});
