'use strict';

var path = require('path');
var auth = require('./../utilities/auth');

module.exports = function (app, rootPath, data) {
  var controllers = require(path.join(rootPath,'/server/controllers'))(data);

  app.use('/users', controllers.users);

  app.get('/', controllers.events.getPast);
  app.get('/events/create', auth.isAuthenticated, controllers.events.getCreate);
  app.post('/events/create', auth.isAuthenticated, controllers.events.postCreate);
  app.get('/events/active', auth.isAuthenticated, controllers.events.getActive);
  app.get('/events/active/:id', auth.isAuthenticated, controllers.events.getDetails);
  app.post('/events/active/:id', auth.isAuthenticated, controllers.events.postDetails);
  app.post('/events/active/:id/comment', auth.isAuthenticated, controllers.events.postComment);

  app.get('*', function (req, res) {
    res.render('404');
  });
};
