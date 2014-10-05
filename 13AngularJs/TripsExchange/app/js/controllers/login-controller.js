/* global app */
'use strict';

app.controller('LoginController', ['$scope', '$location', 'user', 'notifier',
  function LoginCtrl($scope, $location, user, notifier) {

    $scope.user = {};

    $scope.login = function () {
      user.login($scope.user)
        .then(function success () {
          notifier.success('Login Successful');
          $location.path('/');
        },
        function error () {
          notifier.error('Login Failed');
        });
    };

  }
]);
