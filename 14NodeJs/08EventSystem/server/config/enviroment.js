'use strict';

var enviroment = {};

enviroment.dev = {
  connectionString: 'mongodb://localhost:27017/eventSystem',
  port: process.env.PORT || 3000
};

module.exports = enviroment;
