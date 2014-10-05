/* global app */
'use strict';

app.controller('MenuController', ['$scope', 'identity', 'user', 'notifier',
  function MenuCtrl($scope, identity, user, notifier) {

    $scope.user = {};

    $scope.isLoggedIn = function () {
      $scope.user = identity.getCurrentUser();
      return identity.isAuthenticated();
    };

    $scope.logOut = function () {
      user.logout()
        .then(function success() {
          notifier.success('Logged out');
          identity.removeCurrentUser();
        },
        function error() {
          notifier.error('Logging out failed');
        });
    };
  }
]);
