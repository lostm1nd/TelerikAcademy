// By an array of people find the
// most common first and last name

(function() {
  'use strict';

  var student = {
    init: function(firstName, lastName) {
      this.firstName = firstName;
      this.lastName = lastName;
      return this;
    }
  };

  var students = [
    Object.create(student).init('Peter', 'Petrov'),
    Object.create(student).init('Peter', 'Ivanov'),
    Object.create(student).init('Boiko', 'Ivanov'),
    Object.create(student).init('Boyana', 'Ivanova'),
    Object.create(student).init('Iva', 'Ivanova'),
    Object.create(student).init('Alexander', 'Simeonov'),
    Object.create(student).init('Natasha', 'Shtereva')
  ];

  var mostCommonFirstName = _.chain(students)
                              .groupBy('firstName')
                              .max(function(group) {
                                return group.length;
                              })
                              .pluck('firstName')
                              .first()
                              .value();

  var mostCommonLastName = _.chain(students)
                              .groupBy('lastName')
                              .max(function(group) {
                                return group.length;
                              })
                              .pluck('lastName')
                              .first()
                              .value();

  console.log('Most common first name: ' + mostCommonFirstName);

  // obviously max returns the first
  // group of two groups with the same length
  console.log('Most common last name: ' + mostCommonLastName);

}());
