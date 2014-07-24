var CityData = (function() {
  'use strict';

  var cities = ['Sofia', 'Vienna', 'Prague', 'Amsterdam', 'Berlin', 'Budapest'];

  var cityInfo = [];
  cityInfo[0] = [
  '<h3 style="margin:0">Sofia</h3>',
  '<span>the capital of Bulgaria<span>',
  '<p style="margin:0">Population around 1.3 million people</p>'].join('');

  cityInfo[1] = [
  '<h3 style="margin:0">Vienna</h3>',
  '<span>the capital of Austria<span>',
  '<p style="margin:0">Population around 1.8 million people</p>'].join('');

  cityInfo[2] = [
  '<h3 style="margin:0">Prague</h3>',
  '<span>the capital of Czech Republic<span>',
  '<p style="margin:0">Population around 1.24 million people</p>'].join('');

  cityInfo[3] = [
  '<h3 style="margin:0">Amsterdam</h3>',
  '<span>the capital of Netherlands<span>',
  '<p style="margin:0">Population around 0.8 million people</p>'].join('');

  cityInfo[4] = [
  '<h3 style="margin:0">Berlin</h3>',
  '<span>the capital of Germany<span>',
  '<p style="margin:0">Population around 3.5 million people</p>'].join('');

  cityInfo[5] = [
  '<h3 style="margin:0">Budapest</h3>',
  '<span>the capital of Hungary<span>',
  '<p style="margin:0">Population around 3.3 million people</p>'].join('');

  return {
    cities: cities,
    cityInfo: cityInfo
  };

}());
