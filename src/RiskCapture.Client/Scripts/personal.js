(function () {
    "use strict";
    angular._MODULE_ = "question";

    angular
        .module(angular._MODULE_)
        .controller('personal', PersonalController);

    function PersonalController(riskApi) {
        var vm = this;
        vm.Save = function() {
            riskApi.submit(vm);
        };
    };
}());