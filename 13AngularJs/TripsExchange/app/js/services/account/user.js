/* global app */
'use strict';

app.factory('user', ['$http', '$q', 'identity', 'authorization', 'baseUrl',
  function ($http, $q, identity, authorization, baseUrl) {

    var apiUrl = baseUrl + '/api/users';
    var factory = {};

    factory.register = function register(user) {
      var deferred = $q.defer();

      $http.post(apiUrl + '/register', user)
        .success(function () {
          deferred.resolve();
        })
        .error(function (err) {
          deferred.reject(err);
        });

        return deferred.promise;
    };

    factory.login = function login(user) {
      var params = 'grant_type=password&password=' + user.password + '&username=' + user.email;
      var header = { 'Content-Type': 'application/x-www-form-urlencoded' };

      var deferred = $q.defer();

      $http.post(apiUrl + '/login', params, { headers: header })
        .success(function (response) {
          if (response.access_token) {
            user.token = response.access_token;
            identity.saveCurrentUser(user);
            deferred.resolve();
          } else {
            deferred.reject('No access token');
          }
        })
        .error(function (err) {
          deferred.reject(err);
        });

      return deferred.promise;
    };

    factory.logout = function logout() {
      var deferred = $q.defer();
      var header = authorization.getAuthorizationHeader();

      $http.post(apiUrl + '/logout', {}, {headers: header})
        .success(function () {
          deferred.resolve();
        })
        .error(function() {
          deferred.reject();
        });

        return deferred.promise;
    };

    return factory;

  }
]);
