/* global app */
'use strict';

app.factory('trips', ['$http', '$q', 'baseUrl', 'authorization',
  function ($http, $q, baseUrl, authorization) {

    var tripsApi = baseUrl +'/api/trips';
    var factory = {};

    factory.joinTrip = function (id) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      $http.put(tripsApi + '/' + id, {}, {headers: header})
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.reject(err);
        });

      return deferred.promise;
    };

    factory.createTrip = function (trip) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      $http.post(tripsApi, trip, {headers: header})
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.reject(err);
        });

      return deferred.promise;
    };

    factory.executeQuery = function (query) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      var queryString = '?page=' + query.page + '&onlyMine=' + query.onlyMine + '&finished=' + query.finished;

      if (query.fromCity !== '') {
        queryString += '&from=' + query.fromCity;
      }

      if (query.toCity !== '') {
        queryString += '&to=' + query.toCity;
      }

      if (query.orderBy !== '') {
        queryString += '&orderBy=' + query.orderBy;
      }

      if (query.orderType !== '') {
        queryString += '&orderType=' + query.orderType;
      }

      $http.get(tripsApi + queryString, {headers: header})
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.reject(err);
        });

      return deferred.promise;
    };

    factory.getAllTrips = function () {
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

    factory.getLatestAvailableTrips = function () {
      var deferred = $q.defer();

      $http.get(tripsApi + '?page=1&finished=false')
        .success(function (data) {
          deferred.resolve(data);
        })
        .error(function (err) {
          deferred.reject(err);
        });

        return deferred.promise;
    };

    factory.getById = function (id) {
      var header = authorization.getAuthorizationHeader();
      var deferred = $q.defer();

      $http.get(tripsApi + '/' + id, {headers: header})
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
