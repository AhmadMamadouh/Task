/// <reference path="../Scripts/angular.min.js" />

var app = angular.module("Myapp", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when("/ShowStores", {
        templateUrl: "Views/ShowStores.html",
        controller: "myCntrl"

    })
    .when("/StoreControl", {
        templateUrl: "Views/StoreControl.html",
        controller: "myCntrl"

    })
   
});