/* global app */
'use strict';

app.factory('cities', ['$http', '$q', 'baseUrl',
  function ($http, $q, baseUrl) {

    var citiesApi = baseUrl +'/api/cities';
    var factory = {};

    factory.getAll = function () {
      var deferred = $q.defer();

      $http.get(citiesApi)
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
