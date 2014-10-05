/* global app */
'use strict';

app.filter('icon', function () {

  return function (input) {
    return input ? 'images/yes.png' : 'images/no.png';
  };

});
