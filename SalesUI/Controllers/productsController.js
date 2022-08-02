app.controller("productsController", function($rootScope, $scope, $cookies, $routeParams, $http, GLOBAL_CONFIG) {
    $scope.categoryId = $routeParams.categoryId;
    $scope.products = loadProducts();

    $scope.selectProduct = function(product) {
        if (product.stockQty <= 0) {
            return;
        }

        $rootScope.$broadcast('selectProduct', product);
        product.stockQty -= 1;
    }

    $scope.$on('purgedBasket', function (_, _) {
        loadProducts();
    });

    function loadProducts() {
        $http
            .get(GLOBAL_CONFIG.API_URL + "/Product/" + $scope.categoryId)
            .then(
                response => {
                    var selectedProducts = $cookies.getObject('selectedProducts');
                    $scope.products = response.data;

                    if (!selectedProducts) {
                        return;
                    }

                    $scope.products.forEach((i) => {
                        var prod = selectedProducts.find(x => x.id === i.id);

                        if (prod) {
                            i.stockQty -= prod.qty;
                        }
                    });
                },
                error => console.error(error)
            );
    }
});