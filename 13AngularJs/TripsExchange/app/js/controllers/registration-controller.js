/* global app */
'use strict';

app.controller('RegistrationController', ['$scope', '$location', 'notifier', 'user',
  function RegistrationCtrl($scope, $location, notifier, user) {

    $scope.user = {};
    $scope.user.isDriver = true;

    $scope.signUp = function () {
      debugger;
      var newUser = {
        isDriver: $scope.user.isDriver,
        email: $scope.user.email,
        password: $scope.user.password,
        confirmPassword: $scope.user.confirmPassword
      };

      if ($scope.user.isDriver) {
        newUser.car = $scope.user.car;
      }

      user.register(newUser)
        .then(function success() {
          notifier.success('Registration Successful');
          $location.path('/');
        },
        function error () {
          notifier.error('Registration Failed');
        });
    };

  }
]);
