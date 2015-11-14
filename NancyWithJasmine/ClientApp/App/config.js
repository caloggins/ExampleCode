require.config({
    baseUrl: "Scripts",
    paths: {
        app: "../App",
        jquery: "jquery-2.1.4",
        cookie: "js.cookie",
        knockout: "knockout-3.3.0",
        //mapping: "knockout.mapping-latest",
        bootstrap: "bootstrap"
    }
});

requirejs([
    "jquery",
    "knockout",
    //"custom-ko-bindings",
    "app/app",
    "app/files/create-file-register",
    "app/files/company-set-list-register",
    "app/files/create-file-overview-register"
]);
