/* global app */
'use strict';

app.controller('HomeController', ['$scope', 'trips', 'statistics', 'drivers', 'notifier',
  function HomeCtrl($scope, trips, statistics, drivers, notifier) {

    $scope.tripsCount = 0;
    $scope.finishedTripsCount = 0;
    $scope.usersCount = 0;
    $scope.driversCount = 0;

    $scope.trips = [];
    $scope.drivers = [];

    getData();

    function getData() {
      statistics.getStats()
        .then(function success(data) {
          $scope.tripsCount = data.trips;
          $scope.finishedTripsCount = data.finishedTrips;
          $scope.usersCount = data.users;
          $scope.driversCount = data.drivers;
        }, function error() {
          notifier.error('Could not load statistics');
        });

        trips.getLatestAvailableTrips()
          .then(function success(data) {
            $scope.trips = data;
          }, function error() {
            notifier.error('Could not load finished trips');
          });

        drivers.getLatestRegistered()
          .then(function success(data) {
            $scope.drivers = data;
          }, function error() {
            notifier.error('Could not load drivers');
          });
    }

  }
]);
