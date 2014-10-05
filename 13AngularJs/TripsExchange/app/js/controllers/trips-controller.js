/* global app */
'use strict';

app.controller('TripsController', ['$scope', 'trips', 'notifier', 'identity', '$location', 'cities', '$log',
  function TripsCtrl($scope, trips, notifier, identity, $location, cities, $log) {

    $scope.trips = [];
    $scope.allCities = [];
    $scope.isAuthenticated = false;
    $scope.query = {
      page: 1,
      orderBy: '',
      orderType: '',
      toCity: '',
      fromCity: '',
      finished: false,
      onlyMine: false
    };

    $scope.getPrevPage = function () {
      if ($scope.query.page > 1) {
        $scope.query.page -= 1;

        $scope.createQuery($scope.query);
      }
    };

    $scope.getNextPage = function () {
      $scope.query.page += 1;

      $scope.createQuery($scope.query);
    };

    $scope.createQuery = function (query) {
      var promise = trips.executeQuery(query);
      awaitPromise(promise);
    };

    $scope.viewInfo = function (trip) {
      $location.path('/trip-details/' + trip.id);
    };

    $scope.createTrip = function () {
      $location.path('/trips/create');
    };

    getData();

    function getData() {
      $scope.isAuthenticated = identity.isAuthenticated();

      if ($scope.isAuthenticated) {
        $scope.createQuery($scope.query);
      } else {
        var promise = trips.getLatestAvailableTrips();
        awaitPromise(promise);
      }

      cities.getAll()
        .then(function success(data) {
          $scope.allCities = data;
        }, function error(err) {
          $log.error(err);
        });
    }

    function awaitPromise(promise) {
      promise.then(function success(data) {
          $scope.trips = data;
        }, function error() {
          notifier.error('Could not load finished trips');
        });
    }

  }
]);
