'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var encryption = require('../utilities/encryption');
var initiatives = require('./initiative-enum');
var seasons = require('./season-enum');

var userSchema = new Schema({
  username: { type: String, required: '{PATH} is required'},
  email: {type: String, required: '{PATH} is required', unique: true},
  firstName: {type: String, required: '{PATH} is required'},
  lastName: {type: String, required: '{PATH} is required'},
  phone: String,
  points: {
    organization: Number,
    venue: Number
  },
  social: {
    facebook: String,
    twitter: String,
    linkedIn: String,
    googlePlus: String
  },
  initiatives: [{type: String, enum: initiatives}],
  seasons: [{type: String, enum: seasons}],
  profileImage: String,
  salt: String,
  password: String
});

// userSchema.path('name').validate(function (name) {
//   return name.length >= 3;
// }, 'Username must be at least 3 charactes.');

userSchema.methods.authenticate = function (pass) {
  return encryption.generateHash(this.salt, pass) === this.password;
};

module.exports = mongoose.model('User', userSchema);
