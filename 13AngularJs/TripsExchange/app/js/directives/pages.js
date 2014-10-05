/* global app */
'use strict';

app.directive('pages', function () {
  return {
    restrict: 'A',
    templateUrl: 'views/partials/pages.html'
  };
});
