app.controller("indexController", function($scope, $http, $timeout, GLOBAL_CONFIG) {
    $scope.categories = [];
    $scope.alertType = "";
    $scope.alertText = "";
    
    this.$onInit = function() {
        loadCategories();
    }

    $scope.$on('alert', function (_, alert) {
        console.log('test');
        console.log(alert);

        $scope.alertType = alert.type;
        $scope.alertText = alert.text;

        $timeout(() => $scope.closeAlert(), 5000);
    });

    $scope.closeAlert = function() {
        $scope.alertType = "";
        $scope.alertText = "";
    } 

    function loadCategories() {
        $http
            .get(GLOBAL_CONFIG.API_URL + "/Category")
            .then(
                response => $scope.categories = response.data,
                error => console.log(error)
            );
    }
});