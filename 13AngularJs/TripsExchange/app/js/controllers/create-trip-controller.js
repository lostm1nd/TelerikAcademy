/* global app */
'use strict';

app.controller('CreateTripController', ['$scope', 'cities', '$log', 'notifier', 'trips', '$location',
  function CreateTripCtrl($scope, cities, $log, notifier, trips, $location) {

    $scope.availableCities = [];

    $scope.createTrip = function (trip) {
      if (trip.from === trip.to) {
        notifier.error('Cities must be different');
      } else {
        trips.createTrip(trip)
          .then(function success() {
            notifier.success('Trip created');
            $location.path('/trips');
          }, function error(err) {
            notifier.error(err.message);
            $log.error(err);
          });
      }
    };

    getData();

    function getData() {
      cities.getAll()
        .then(function success(data) {
          $scope.availableCities = data;
        }, function error(err) {
          notifier.error('Could not load the cities');
          $log.error(err);
        });
    }
  }
]);
