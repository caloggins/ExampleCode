define(["jquery", "knockout"], function($, ko) {
    function greetingControlViewModel(parameters) {
        var self = this;

        self.greeting = ko.observable("");

        parameters.bus.subscribe(function() {
            $.getJSON("/health", "", function(data) {
                self.greeting(data);
            });
        }, self, "logged-in");
    };

    return greetingControlViewModel;
})