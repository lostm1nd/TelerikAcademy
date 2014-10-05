/* global app */
'use strict';

app.factory('authorization', ['identity', function (identity) {

  var factory = {};

  factory.getAuthorizationHeader = function () {
    var token = identity.getCurrentUser().token;
    var header = {
      'Authorization': 'Bearer ' + token
    };

    return header;
  };

  return factory;

}]);
