'use strict';

var app = angular.module("salesApp", ["ngRoute", "ngCookies"])
    .constant('GLOBAL_CONFIG', {
        'API_URL': 'https://localhost:7174/api'
    });
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "Views/main.html"
        })
        .when("/products/:categoryId", {
            templateUrl: "Views/products.html",
            controller: "productsController"
        })
        .when("/checkout", {
            templateUrl: "Views/checkout.html",
            controller: "checkoutController",
            resolve: {
                factory: ($cookies, $location) => {
                    if (!$cookies.getObject('selectedProducts'))
                    {
                        $location.path('/');
                    }
                }
            }
        });
});