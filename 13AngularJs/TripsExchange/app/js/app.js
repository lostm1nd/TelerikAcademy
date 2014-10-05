/* global toastr, angular */
'use strict';

var app = angular.module('webApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
  $routeProvider
    .when('/', {
      templateUrl: 'views/partials/welcome.html',
      controller: 'HomeController'
    })
    .when('/drivers', {
      templateUrl: 'views/partials/drivers.html',
      controller: 'DriversController'
    })
    .when('/driver-details/:id', {
      templateUrl: 'views/partials/driver-details.html',
      controller: 'DriverDetailsController'
    })
    .when('/trips', {
      templateUrl: 'views/partials/trips.html',
      controller: 'TripsController'
    })
    .when('/trips/create', {
      templateUrl: 'views/partials/create-trip.html',
      controller: 'CreateTripController'
    })
    .when('/trip-details/:id', {
      templateUrl: 'views/partials/trip-details.html',
      controller: 'TripDetailsController'
    })
    .when('/login', {
      templateUrl: 'views/partials/login.html',
      controller: 'LoginController'
    })
    .when('/register', {
      templateUrl: 'views/partials/register.html',
      controller: 'RegistrationController'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);

app.value('toastr', toastr);
app.constant('baseUrl', 'http://spa2014.bgcoder.com');
// http://fdietz.github.io/recipes-with-angular-js/urls-routing-and-partials/listening-on-route-changes-to-implement-a-login-mechanism.html
