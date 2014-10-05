/* global app */
'use strict';

app.controller('DriversController', ['$scope', 'drivers', 'notifier', 'identity', '$location',
  function DriversCtrl($scope, drivers, notifier, identity, $location) {

    $scope.drivers = [];
    $scope.isAuthenticated = false;
    $scope.query = {};
    $scope.query.page = 1;

    $scope.getPrevPage = function () {
      if ($scope.query.page > 1) {
        $scope.query.page -= 1;

        getByPage($scope.query.page);
      }
    };

    $scope.getNextPage = function () {
      $scope.query.page += 1;

      getByPage($scope.query.page);
    };

    $scope.viewInfo = function (user) {
      $location.path('/driver-details/' + user.id);
    };

    getData();

    function getByPage(page) {
      drivers.getByPage(page)
        .then(function success(data) {
          $scope.drivers = data;
        }, function error() {
          notifier.error('Could not load drivers');
        });
    }

    function getData() {
      $scope.isAuthenticated = identity.isAuthenticated();

      if ($scope.isAuthenticated) {
        getByPage($scope.query.page);
      } else {
        drivers.getLatestRegistered()
          .then(function success(data) {
            $scope.drivers = data;
          }, function error() {
            notifier.error('Could not load drivers');
          });
      }
    }

  }
]);
