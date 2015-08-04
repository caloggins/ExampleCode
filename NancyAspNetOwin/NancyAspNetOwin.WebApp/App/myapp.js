define(["jquery", "knockout"], function ($, ko) {
    var myapp = {
        token: ko.observable(""),
        bus: new ko.subscribable()
    };

    myapp.showToken = ko.computed(function () {
        return myapp.token().length > 0;
    });

    myapp.showLoginButton = ko.computed(function() {
        return myapp.token().length === 0;
    });

    myapp.showLoginForm = function () {
        $("#loginForm").modal("show");
    }

    $(document).ready(function () {
        ko.applyBindings(myapp);
    });
});