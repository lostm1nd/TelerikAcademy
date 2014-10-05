/* global app */
'use strict';

app.controller('TripDetailsController', ['$scope', '$routeParams', 'trips', '$log', 'notifier',
  function TripDetailsCtrl($scope, $routeParams, trips, $log, notifier) {

    $scope.tripDetails = {};

    $scope.joinTrip = function () {
      trips.joinTrip($scope.tripDetails.id)
        .then(function success() {
          notifier.success('Trip joined');
        }, function error(err) {
          notifier.error('Could not join the trip');
          $log.error(err);
        });
    };

    getData();

    function getData() {
      trips.getById($routeParams.id)
        .then(function success(data) {
          $scope.tripDetails = data;
        }, function error(err) {
          $log.error(err);
        });
    }

  }
]);
