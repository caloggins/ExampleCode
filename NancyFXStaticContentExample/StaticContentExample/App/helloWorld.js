var MyViewModel = function() {
    this.greeting = ko.observable("I'm Knocked Out!");
}


$(document).ready(function() {
    var viewModel = new MyViewModel();

    ko.applyBindings(viewModel);
});
