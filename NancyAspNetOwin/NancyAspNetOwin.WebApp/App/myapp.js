define(["jquery", "knockout", "cookie"], function ($, ko) {

    //console.log(typeof $.cookie);

    var myapp = {
        token: ko.observable(""),//.extend({ cookie: 'token' }),
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