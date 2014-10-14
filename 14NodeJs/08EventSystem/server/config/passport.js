'use strict';

var passport = require('passport');
var LocalStrategy = require('passport-local').Strategy;

module.exports = function (userData) {
  passport.serializeUser(function(user, done) {
    done(null, user.id);
  });

  passport.deserializeUser(function(id, done) {
    userData.findById(id)
      .then(function success(user) {
        done(null, user);
      }, function (err) {
        done(err, null);
      });
  });

  passport.use('local-login', new LocalStrategy({
    usernameField: 'email',
    passwordField: 'password',
  }, function(email, password, done) {
    userData.findByEmail(email)
      .then(function success(user) {
        if (!user) {
          return done(null, false, { message: 'Incorrect email' });
        }

        if (!user.authenticate(password)) {
          return done(null, false, { message: 'Incorrect password' });
        }

        return done(null, user);
      }, function error(err) {
        return done(err);
      });
  }));
};
