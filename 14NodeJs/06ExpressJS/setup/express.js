var path = require('path');
var express = require('express');
var morgan = require('morgan');
var bodyParser = require('body-parser');
var cookieParser = require('cookie-parser');
var favicon = require('serve-favicon');
var passport = require('passport');
var session = require('express-session');
var moment = require('moment');

module.exports = function (app, rootPath) {
  app.set('views', path.join(rootPath, '/views'));
  app.set('view engine', 'jade');

  app.locals.moment = moment;

  app.use(express.static(path.join(rootPath, '/public')));
  app.use(favicon(path.join(rootPath, '/public/favicon.ico')));

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
};
