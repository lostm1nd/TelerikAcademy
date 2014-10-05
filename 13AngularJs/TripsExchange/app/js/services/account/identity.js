/* global app */
'use strict';

app.factory('identity', function () {

  var username = '';
  var token = '';

  var factory = {};

  factory.saveCurrentUser = function saveCurrentUser(user) {
    username = user.email;
    token = user.token;
  };

  factory.getCurrentUser = function getCurrentUser() {
    return {
      username: username,
      token: token
    };
  };

  factory.removeCurrentUser = function removeCurrentUser() {
    username = '';
    token = '';
  };

  factory.isAuthenticated = function isAuthenticated() {
    return token !== '';
  };

  return factory;

});
