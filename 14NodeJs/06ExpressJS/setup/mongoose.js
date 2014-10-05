var path = require('path');
var mongoose = require('mongoose');

module.exports = function(connectionString, rootPath) {
  require(path.join(rootPath, '/models/post'));
  require(path.join(rootPath, '/models/user'));

  mongoose.connect(connectionString);
  var db = mongoose.connection;

  db.on('error', function(msg) {
    console.log('Mongoose connection error %s', msg);
  });

  db.once('open', function() {
    console.log('Mongoose connection established');
  });
};
