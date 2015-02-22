(function () {
    "use strict";
    angular._MODULE_ = "question";
    angular
        .module(angular._MODULE_, ["ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider
                .when("/personal/:riskId", template("personal"))
                .otherwise({ redirectTo: "/new" });
        });

    function template(name) {
        return{
            templateUrl: function() {
                return "content/pages/template/" + name + ".html";
            },
            controller: name,
            controllerAs: name
        };
    };
}());