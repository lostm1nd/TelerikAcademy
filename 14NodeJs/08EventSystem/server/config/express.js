'use strict';

var path = require('path');
var express = require('express');
var session = require('express-session');
var passport = require('passport');
var bodyParser = require('body-parser');
var cookieParser = require('cookie-parser');
var morgan = require('morgan');
var moment = require('moment');

module.exports = function(app, rootPath) {
  app.set('view engine', 'jade');
  app.set('views', rootPath + '/server/views');
  app.locals.moment = moment;

  app.use(express.static(path.join(rootPath, '/public')));
  app.use(morgan('dev'));
  app.use(cookieParser());
  app.use(bodyParser.json());
  app.use(bodyParser.urlencoded({ extended: true }));

  app.use(session({
    secret: 'threelongbeards',
    resave: true,
    saveUninitialized: true
  }));
  app.use(passport.initialize());
  app.use(passport.session());

  app.use(function (req, res, next) {
    if (req.user) {
      app.locals.currentUser = req.user.username;
    } else {
      app.locals.currentUser = undefined;
    }

    app.locals.successMessage = req.session.successMessage;
    app.locals.infoMessage = req.session.infoMessage;
    app.locals.errorMessage = req.session.errorMessage;

    req.session.successMessage = undefined;
    req.session.infoMessage = undefined;
    req.session.errorMessage = undefined;

    next();
  });
};
