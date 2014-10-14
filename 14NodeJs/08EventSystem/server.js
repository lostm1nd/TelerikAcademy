'use strict';

var rootPath = require('path').normalize(__dirname);
var express = require('express');

var env = process.env.NODE_ENV || 'dev';
var settings = require('./server/config/enviroment')[env];

var app = express();

require('./server/config/mongoose')(settings.connectionString, rootPath);

// load it after mongoose has initilized the models
// uncomment the sample data to use it :)
// require('./server/utilities/sample-data')();
var data = require('./server/data');

require('./server/config/passport')(data.users);
require('./server/config/express')(app, rootPath);
require('./server/config/routes')(app, rootPath, data);

app.listen(settings.port);
console.log('Server started on port: ' + settings.port);
