'use strict';

var auth = require('./../utilities/auth');
var contollers = {};

module.exports = function (data) {
  contollers.users = require('./users-controller')(auth, data.users);
  contollers.events = require('./events-controller')(data.events);

  return contollers;
};
