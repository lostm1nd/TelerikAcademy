var path = require('path');

module.exports = function (app, rootPath) {
  var home = require(path.join(rootPath, '/routes/home'));
  var posts = require(path.join(rootPath, '/routes/posts'));
  var users = require(path.join(rootPath, '/routes/users'));

  app.use('/', home);
  app.use('/posts', posts);
  app.use('/users', users);
};
