'use strict';

var Q = require('q');
var encryption = require('./../utilities/encryption');
var User = require('mongoose').model('User');
var data = {};

data.create = function (user) {
  var deferred = Q.defer();

  User.findOne({email: user.email})
  .exec(function (err, userFromDb) {
    if(err) {
      return deferred.reject(err);
    }

    if (userFromDb) {
      return deferred.reject({message: 'Email is already taken'});
    }

    var salt = encryption.generateSalt();
    var newUser = new User({
      username: user.username,
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      phone: user.phone,
      social: {
        facebook: user.facebook,
        twitter: user.twitter,
        linkedIn: user.linkedIn,
        googlePlus: user.googlePlus
      },
      initiatives: user.initiatives,
      seasons: user.seasons,
      salt: salt,
      password: encryption.generateHash(salt, user.password)
    });

    newUser.save(function (err, saved) {
      if (err) {
        return deferred.reject(err);
      }

      return deferred.resolve({
        name: saved.name,
        email: saved.email
      });
    });

  });

  return deferred.promise;
};

data.findById = function (id) {
  var deferred = Q.defer();

  User.findById(id)
  .exec(function (err, user) {
    if(err) {
      return deferred.reject(err);
    }

    return deferred.resolve(user);
  });

  return deferred.promise;
};

data.findByEmail = function (email) {
  var deferred = Q.defer();

  User.findOne({ email: email })
  .exec(function (err, user) {
    if(err) {
      return deferred.reject(err);
    }

    return deferred.resolve(user);
  });

  return deferred.promise;
};

data.updateUser = function (id, update) {
  var deferred = Q.defer();

  User.findById(id)
  .exec(function (err, user) {
    if (err) {
      return deferred.reject(err);
    }

    Object.keys(update).forEach(function (key) {
      user[key] = update[key];
    });

    user.save(function (err, saved) {
      if (err) {
        return deferred.reject(err);
      }

      deferred.resolve(saved);
    });
  });

  return deferred.promise;
};

module.exports = data;
