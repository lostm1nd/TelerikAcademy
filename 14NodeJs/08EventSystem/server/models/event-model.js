'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var initiatives = require('./initiative-enum');
var seasons = require('./season-enum');

var eventSchema = new Schema({
  title: { type: String, required: '{PATH} is required'},
  description: { type: String, required: '{PATH} is required'},
  date: Date,
  location: {
    latitude: String,
    longitude: String
  },
  category: String,
  type: {
    initiative: {type: String, enum: initiatives},
    season: {type: String, enum: seasons}
  },
  creator: {
    username: String,
    phone: String
  },
  points: {
    organization: Number,
    venue: Number
  },
  comments: [String],
  attendants: [String]
});

module.exports = mongoose.model('Event', eventSchema);
