'use strict';

var LOGIN_SUCCESS = 'You have logged in successfully.';
var LOGOUT_SUCCESS = 'You have logged out successfully.';
var AUTH_FAILURE = 'You need to be authenticated to access ';

var passport = require('passport');
var auth = {};

auth.login = function(req, res, next) {
  passport.authenticate('local-login', function(err, user, info) {
    if (err) {
      return next(err);
    }

    if (!user) {
      req.session.errorMessage = info.message;
      return res.redirect('/users/login');
    }

    req.logIn(user, function(err) {
      if (err) {
        return next(err);
      }

      req.session.successMessage = LOGIN_SUCCESS;
      return res.redirect('/');
    });
  })(req, res, next);
};

auth.logout = function (req, res, next) {
  req.logout();
  req.session.successMessage = LOGOUT_SUCCESS;
  res.redirect('/');
};

auth.isAuthenticated = function (req, res, next) {
  if (!req.isAuthenticated()) {
    req.session.errorMessage = AUTH_FAILURE + req.path;
    return res.redirect('/users/login');
  }

  next();
};

module.exports = auth;
