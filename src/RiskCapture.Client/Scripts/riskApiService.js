(function () {
    "use strict";

    angular
        .module(angular._MODULE_)
        .factory('riskApi', RiskApi);

    function RiskApi($window, $routeParams, $http) {
        return{
            submit : submit
        }
        function submit(data) {
            var riskId = $routeParams.riskId;
            var location = $window.location.protocol +
                '//' + $window.location.hostname + 
                ":30141/api/risk/" + riskId + "/sections/" + "personal";
            $http.post(location, data)
                .then(function(response) {
                
                })
                ["catch"](function(response) {
                console.log(response);
            });
        }
    }
}());