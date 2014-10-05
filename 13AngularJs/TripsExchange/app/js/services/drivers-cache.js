/* global app */
'use strict';

app.factory('driversCache', ['drivers', '$log',
  function (drivers, $log) {

    var factory = {};

    factory.all = {};
    factory.latestRegistered = {};

    getData();

    factory.refresh = function () {
      getData();
    };

    function getData() {
      drivers.getLatestRegistered()
        .then(function success(data) {
          factory.latestRegistered = data;
        }, function error() {
          $log.error('error when getting drivers in driversCache');
        });
    }

    return factory;

  }
]);
