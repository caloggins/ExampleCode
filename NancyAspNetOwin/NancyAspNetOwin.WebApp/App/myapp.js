define(["jquery", "knockout", "cookie"], function ($, ko, cookies) {

    // how to do stuff w/ cookies
    cookies.set("sample", "my cookie value");
    var myval = cookies.get("sample");
    console.log(myval);

    var myapp = {
        // put the token in a cookie, and make it observable
        token: ko.observable("").extend({ cookie: "token" }),
        bus: new ko.subscribable()
    };

    myapp.showToken = ko.computed(function () {
        return myapp.token().length > 0;
    });

    myapp.showLoginButton = ko.computed(function () {
        return myapp.token().length === 0;
    });

    myapp.showLoginForm = function () {
        $("#loginForm").modal("show");
    }

    $(document).ready(function () {
        ko.applyBindings(myapp);
    });
});