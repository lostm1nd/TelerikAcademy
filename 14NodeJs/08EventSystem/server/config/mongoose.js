'use strict';

var path = require('path');
var mongoose = require('mongoose');

module.exports = function(connectionString, rootPath) {
  require(path.join(rootPath, '/server/models/user-model'));
  require(path.join(rootPath, '/server/models/event-model'));

  mongoose.connect(connectionString);
  var db = mongoose.connection;

  db.on('error', function(msg) {
    console.log('Mongoose connection error %s', msg);
  });

  db.once('open', function() {
    console.log('Mongoose connection established');
  });
};
