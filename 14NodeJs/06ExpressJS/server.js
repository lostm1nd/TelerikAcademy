var path = require('path');
var express = require('express');
var passport = require('passport');

var rootPath = path.normalize(__dirname);

var app = express();

require('./setup/mongoose')('localhost:27017/blog', rootPath);

require('./setup/passport')(passport);
require('./setup/express')(app, rootPath);

require('./setup/routes')(app, rootPath);

app.listen(3000);
console.log('Server running on port: 3000');
