define(["jQuery", "knockout"], function ($, ko) {
    function extender() {
        if (typeof ($.cookie) === "undefined") { return; }

        ko.extenders.cookie = function (target, key) {
            var initialValue = target();

            if (key && $.cookie(key) !== null) {
                try {
                    initialValue = JSON.parse($.cookie(key));
                } catch (e) {
                }
            }

            target(initialValue);

            target.subscribe(function (newValue) {
                $.cookie(key, ko.toJSON(newValue));
            });

            return target;
        }
    };

    return extender;
})
