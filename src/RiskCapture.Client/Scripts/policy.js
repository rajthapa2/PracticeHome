(function () {
    "use strict";
    angular._MODULE_ = "question";

    angular
        .module(angular._MODULE_)
        .controller('policy', PolicyController);

    function PolicyController() {
        var vm = this;
        this.id = "hello";
    };
}());