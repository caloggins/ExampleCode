define(["require", "knockout"], function (require, ko) {
    ko.components.register("login", {
        viewModel: { require: "app/authentication/login-control" },
        template: { require: "text!app/authentication/login-control.html" }
    });
});