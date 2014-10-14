'use strict';

var USERNAME_REGEX = new RegExp('[^a-zA-Z0-9_\\.\\s]');
var REGISTER_SUCCESS = 'Your registration was successful.';
var INVALID_USERNAME_LENGTH = 'Username must be between 6 and 20 characters.';
var INVALID_CHARACTERS = 'Allowed characters are letters, digits, space, underscore and dot.';
var PASSWORD_MISMATCH = 'Passwords do not match.';
var PROFILE_UPDATE = 'Your profile has been updated.';

var router = require('express').Router();

module.exports = function (auth, userData) {
  router.get('/register', function (req, res) {
    res.render('users/register');
  });

  router.post('/register', function (req, res) {
    if (req.body.password !== req.body.confirmPassword) {
      req.session.errorMessage = PASSWORD_MISMATCH;
      return res.redirect('/users/register');
    }

    if (req.body.username.length < 6 || req.body.username.length > 20) {
      req.session.errorMessage = INVALID_USERNAME_LENGTH;
      return res.redirect('/users/register');
    }

    if (USERNAME_REGEX.test(req.body.username)) {
      req.session.errorMessage = INVALID_CHARACTERS;
      return res.redirect('/users/register');
    }

    userData.create(req.body)
      .then(function success(user) {
        req.session.successMessage = REGISTER_SUCCESS;
        res.redirect('/users/login');
      }, function error(err) {
        req.session.errorMessage = err.message;
        res.redirect('/users/register');
      });
  });

  router.get('/login', function (req, res) {
    res.render('users/login');
  });

  router.post('/login', auth.login);

  router.get('/logout', auth.isAuthenticated, auth.logout);

  router.get('/profile', auth.isAuthenticated, function (req, res) {
    res.render('users/profile', {user: req.user});
  });

  router.post('/profile', auth.isAuthenticated, function (req, res) {
    userData.updateUser(req.user._id, req.body)
      .then(function success(user) {
        req.session.successMessage = PROFILE_UPDATE;
        res.redirect('/users/profile');
      }, function error(err) {
        req.session.errorMessage = err.message;
        res.redirect('/users/profile');
      });
  });

  return router;
};
