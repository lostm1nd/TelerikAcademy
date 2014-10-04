/* global require, console */
'use strict';

var mongodb = require('mongodb');

var server = new mongodb.Server('localhost', 27017);
var client = new mongodb.MongoClient(server);

client.open(function (err, client) {
  var db = client.db('test');
  var courses = db.collection('courses');

  // for (var i = 1; i <= 5; i++) {
  //   courses.insert({ name: 'NodeJS', lectures: i }, { w: 0 });
  // }

  // for (i = 1; i <= 5; i++) {
  //   courses.insert({ name: 'MongoDb', lectures: i }, { w: 0 });
  // }

  courses.find().toArray(function (err, results) {
    if (err) {
      console.log(err);
    }

    console.log('============All courses with find()==============');
    console.log(results);
    console.log('=========End of all courses with find()==========');
  });

  var stream = courses.find().stream();

  stream.on('data', function (data) {
    console.log(data);
  });

  stream.on('end', function() {
    console.log('No more data');
  });

  courses.find({name: 'NodeJS'}).toArray(function(err, results) {
    console.log('============Only NodeJS Courses==============');
    console.log(results);
    console.log('=========End of only NodeJS Courses==========');
  });

  courses.find().skip(4).limit(2).toArray(function(err, results) {
    console.log('============Skip 4 Limit 2==============');
    console.log(results);
    console.log('=========End of Skip 4 Limit 2==========');
  });

  courses.find({lectures: {$gt: 2, $lt: 5}}).toArray(function(err, results) {
    console.log('===========From 2 to 4 lectures============');
    console.log(results);
    console.log('=========End from 2 to 4 lectures==========');
  });

});
