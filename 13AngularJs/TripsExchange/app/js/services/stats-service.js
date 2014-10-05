/* global app */
'use strict';

app.factory('statistics', ['$http', '$q', 'baseUrl',
  function ($http, $q, baseUrl) {

    var tripsApi = baseUrl +'/api/stats';
    var factory = {};

    factory.getStats = function () {
      var deferred = $q.defer();

      $http.get(tripsApi)
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.reject(err);
        });

        return deferred.promise;
    };

    return factory;

  }
]);
