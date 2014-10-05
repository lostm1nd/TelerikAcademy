/* global app */
'use strict';

app.filter('date', function () {

  return function (input) {
    var date = new Date(input);

    return date.getDate() + '/' +
      date.getMonth() + '/' +
      date.getFullYear() + ' at ' +
      date.getHours() + ':' + date.getMinutes();
  };

});
