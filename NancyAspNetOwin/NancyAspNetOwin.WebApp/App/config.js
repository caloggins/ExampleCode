requirejs.config({
    baseUrl: "Scripts",
    paths: {
        app: "../App",
        myapp: "app/myapp",
        jquery: "jquery-2.1.4",
        cookie: "jquery.cookie",
        knockout: "knockout-3.3.0.debug",
        bootstrap: "bootstrap"
    }
});

requirejs(["app/myapp",
    "app/authentication/login-control-register",
    "app/greeting/greeting-control-register"
]);