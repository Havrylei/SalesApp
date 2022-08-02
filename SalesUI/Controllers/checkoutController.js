app.controller("checkoutController", function($rootScope, $scope, $location, $cookies, $http, GLOBAL_CONFIG) {
    $scope.selectedProducts = $cookies.getObject('selectedProducts');
    $scope.totalAmount = $scope.selectedProducts.reduce((sum, el) => sum + (el.price * el.qty), 0);
    $scope.incomingAmount = 0;
    $scope.isBuyPressed = false;

    $scope.commitSale = function() {
        $scope.isBuyPressed = true;
        
        var data = $scope.selectedProducts.map(x => ({ productId: x.id, qty: x.qty }));

        $rootScope.$broadcast('resetBasket');
        $http
            .post(GLOBAL_CONFIG.API_URL + "/Order/Create", data)
            .then(
                _ => {
                    $rootScope.$broadcast('alert', { type: "success", text: "The purchase is successful" });
                    $location.path('/');
                },
                error => {
                    $rootScope.$broadcast('alert', { type: "error", text: error });
                    console.error(error);
                    $location.path('/');
                }
            );
    }
});