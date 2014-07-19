// Write a function that by a given array of
// students finds the student with highest marks.

(function() {
  'use strict';

  var student = {
    init: function(firstName, lastName, mark) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.mark = mark;
      return this;
    }
  };

  var students = [
    Object.create(student).init('Peter', 'Petrov', 5.50),
    Object.create(student).init('Boiko', 'Aleksiev', 6.00),
    Object.create(student).init('Natasha', 'Shtereva', 5.75),
    Object.create(student).init('Sasha', 'Natalieva', 6.00),
    Object.create(student).init('Alexander', 'Simeonov', 5.25),
    Object.create(student).init('Bojil', 'Binev', 5.00),
    Object.create(student).init('Boyana', 'Aleksieva', 5.75)
  ];

  var highestMark = _.chain(students).sortBy('mark').reverse().first().value();

  var maxMark = _.chain(students).max(function(student) {
    return student.mark;
  }).value();

  console.log(highestMark);
  console.log(maxMark);

}());
