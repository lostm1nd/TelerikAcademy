/* global app */
'use strict';

app.factory('drivers', ['$http', '$q', 'baseUrl', 'authorization',
  function ($http, $q, baseUrl, authorization) {

    var driversApi = baseUrl + '/api/drivers';
    var factory = {};

    factory.getLatestRegistered = function () {
      var deferred = $q.defer();

      $http.get(driversApi + '?page=1')
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.resolve(err);
        });

        return deferred.promise;
    };

    factory.getByPage = function (page) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      $http.get(driversApi + '?page=' + page, {headers: header})
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.resolve(err);
        });

        return deferred.promise;
    };

    factory.getById = function (id) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      $http.get(driversApi + '/' + id, {headers: header})
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.resolve(err);
        });

        return deferred.promise;
    };

    return factory;

  }
]);
