'use strict';

var crypto = require('crypto');
var encryption = {};

encryption.generateSalt = function() {
  return crypto.randomBytes(128).toString('base64');
};

encryption.generateHash = function(salt, text) {
  var hmac = crypto.createHmac('sha1', salt);
  return hmac.update(text).digest('hex');
};

module.exports = encryption;
