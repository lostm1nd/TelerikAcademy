'use strict';

var encryption = require('./encryption');
var User = require('mongoose').model('User');
var Event = require('mongoose').model('Event');

module.exports = function () {
  var saltForPan = encryption.generateSalt();
  User.create({
    username: 'Pan',
    email: 'pan@pan.com',
    firstName: 'Peter',
    lastName: 'Pan',
    phone: '029990099',
    initiatives: ['Software Academy'],
    seasons: ['Started 2013'],
    salt: saltForPan,
    password: encryption.generateHash(saltForPan, '123456')
  }, function (err, user) {
    if (err) {
      console.log(err);
    }

    console.log('Peter Pan created');
  });

  var saltForLeia = encryption.generateSalt();
  User.create({
    username: 'Leia',
    email: 'leia@princess.com',
    firstName: 'Princess',
    lastName: 'Leia',
    phone: '0888222333',
    initiatives: ['Software Academy', 'Algo Academy'],
    seasons: ['Started 2013'],
    salt: saltForLeia,
    password: encryption.generateHash(saltForLeia, '123456')
  }, function (err, user) {
    if (err) {
      console.log(err);
    }

    console.log('Princess Leia created');
  });

  Event.create({
    title: 'Mascarade',
    description: 'Masks are required',
    date: new Date(2014, 7, 11, 18, 30),
    location: { latitude: 123.21, longitude: 99.012},
    category: 'party',
    creator: {
      username: 'Leia',
      phone: '0888222333'
    },
    points: {
      organization: 150,
      venue: 1000
    }
  }, function (err, event) {

  });

  Event.create({
    title: 'Football',
    description: 'Only girls',
    date: new Date(2014, 7, 11, 18, 30),
    location: { latitude: 12.321, longitude: 90.11},
    category: 'sports',
    creator: {
      username: 'Leia',
      phone: '0888222333'
    },
    points: {
      organization: 25,
      venue: 50
    }
  }, function (err, event) {

  });

  Event.create({
    title: 'Football',
    description: 'Only pros',
    date: new Date(2014, 7, 11, 18, 30),
    location: { latitude: 12.321, longitude: 90.11},
    category: 'sports',
    creator: {
      username: 'Pan',
      phone: '029990099'
    },
    points: {
      organization: 25,
      venue: 50
    }
  }, function (err, event) {

  });

  Event.create({
    title: 'Dancing',
    description: 'yupiii',
    date: new Date(2014, 12, 11, 18, 30),
    location: { latitude: 12.321, longitude: 90.11},
    category: 'free time',
    creator: {
      username: 'Leia',
      phone: '0888222333'
    },
    points: {
      organization: 25,
      venue: 50
    }
  }, function (err, event) {

  });

  Event.create({
    title: 'Singing',
    description: 'yupiii',
    date: new Date(2014, 12, 11, 17, 30),
    location: { latitude: 12.321, longitude: 90.11},
    category: 'free time',
    creator: {
      username: 'Leia',
      phone: '0888222333'
    },
    points: {
      organization: 25,
      venue: 50
    }
  }, function (err, event) {

  });
};
