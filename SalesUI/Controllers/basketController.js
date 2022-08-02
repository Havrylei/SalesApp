app.controller("basketController", function($rootScope, $scope, $cookies) {
    $scope.totalAmount = 0;
    $scope.selectedProducts = $cookies.getObject('selectedProducts') || [];

    this.$onInit = function() {
        recalcTotalAmount();
    }

    $scope.$on('selectProduct', function (_, product) {
        var selectedProduct = $scope.selectedProducts.find(x => x.id === product.id);

        if (!selectedProduct) {
            selectedProduct = {
                id: product.id,
                name: product.name,
                price: product.price,
                qty: 1
            }

            $scope.selectedProducts.push(selectedProduct);
        } else {
            selectedProduct.qty += 1;
        }
        
        $cookies.putObject("selectedProducts", $scope.selectedProducts, {
            secure: true,
            expires: new Date(new Date().getTime() + 30 * 60 * 1000).toString()
        });

        recalcTotalAmount();
    });

    $scope.$on('resetBasket', function (_, _) {
        $scope.resetBasket();
    });

    $scope.resetBasket = function () {
        $cookies.remove('selectedProducts');
        $scope.selectedProducts = [];
        $scope.totalAmount = 0;
        $rootScope.$broadcast('purgedBasket');
    }

    function recalcTotalAmount() {
        $scope.totalAmount = $scope.selectedProducts.reduce((sum, el) => sum + (el.price * el.qty), 0);
    } 
});