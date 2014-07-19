// Write function that finds the first name and last name
// of all students with age between 18 and 24.

(function() {
  'use strict';

  var student = {
    init: function(firstName, lastName, age) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.age = age;
      return this;
    }
  };

  var students = [
    Object.create(student).init('Peter', 'Petrov', 17),
    Object.create(student).init('Boiko', 'Aleksiev', 34),
    Object.create(student).init('Natasha', 'Shtereva', 22),
    Object.create(student).init('Sasha', 'Natalieva', 18),
    Object.create(student).init('Alexander', 'Simeonov', 21),
    Object.create(student).init('Bojil', 'Binev', 23),
    Object.create(student).init('Boyana', 'Aleksieva', 25)
  ];

  _.chain(students)
    .filter(function(student) {
      return 18 < student.age && student.age < 24;
    })
    .sortBy('age')
    .map(function(student) {
      return student.firstName + ' ' + student.lastName + ' -> ' + student.age;
    })
    .each(function(name) {
      console.log(name);
    });

}());
