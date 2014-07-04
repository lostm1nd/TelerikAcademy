(function() {
  'use strict';

  var people = [
  { id: 1, name: 'Doncho Minkov', age: 21, avatarUrl: 'images/doncho.jpg' },
  { id: 2, name: 'Ivaylo Kenov', age: 22, avatarUrl: 'images/ivo.jpg' },
  { id: 3, name: 'Nikolay Kostov', age: 23, avatarUrl: 'images/niki.jpg' },
  { id: 4, name: 'Todor Stoyanov', age: 22, avatarUrl: 'images/todor.jpg' }];

  var people2 = [
  { id: 5, name: 'Nikolay Kostov', age: 23, avatarUrl: 'images/niki.jpg' },
  { id: 6, name: 'Doncho Minkov', age: 21, avatarUrl: 'images/doncho.jpg' },
  { id: 7, name: 'Todor Stoyanov', age: 22, avatarUrl: 'images/todor.jpg' }];

  require.config({
    paths: {
      'handlebars': 'libs/handlebars.min',
      'jquery': 'libs/jquery.min',
      'controls': 'scripts/controls'
    }
  });

  require(['jquery', 'controls'], function($, controls) {
    var comboBox = controls.ComboBox(people),
        template = $("#person-template").html(),
        comboBoxHtml = comboBox.render(template);

    var comboBox2 = controls.ComboBox(people2),
        comboBoxHtml2 = comboBox.render(template);

    $('#combo-box').append(comboBoxHtml);
    $('#combo-box2').append(comboBoxHtml2);
  });

}());
