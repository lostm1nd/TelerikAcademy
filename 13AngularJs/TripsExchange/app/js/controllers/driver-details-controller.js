/* global app */
'use strict';

app.controller('DriverDetailsController', ['$scope', '$routeParams', 'drivers', '$log',
  function DriverDetailsCtrl($scope, $routeParams, drivers, $log) {

    $scope.driverDetails = {};

    getData();

    function getData() {
      drivers.getById($routeParams.id)
        .then(function success(data) {
          $scope.driverDetails = data;
        }, function error(err) {
          $log.error(err);
        });
    }
  }
]);
