/* global app */
'use strict';

app.directive('menu', function () {
  return {
    restrict: 'A',
    templateUrl: 'views/partials/menu.html',
    controller: 'MenuController'
  };
});
