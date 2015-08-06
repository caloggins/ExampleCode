define(["require", "knockout"], function (require, ko) {
    ko.components.register("greeting", {
        viewModel: { require: "app/greeting/greeting-control" },
        template: { require: "text!app/greeting/greeting-control.html" }
    });
});