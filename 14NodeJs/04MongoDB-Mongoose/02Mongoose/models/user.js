/* global require, module */
'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var userSchema = new Schema({
  username: String,
  pass: String
});

var User = mongoose.model('User', userSchema);

module.exports = User;
