// Write a method that from a given array of students finds all students
// whose first name is before its last name alphabetically.
// Print the students in descending order by full name.

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
    Object.create(student).init('Alexander', 'Simeonov'),
    Object.create(student).init('Boiko', 'Aleksiev'),
    Object.create(student).init('Natasha', 'Shtereva'),
    Object.create(student).init('Boyana', 'Aleksieva')
  ];

  _.chain(students)
    .filter(function(student) {
      return student.firstName < student.lastName;
    })
    .sortBy('firstName')
    .each(function(student) {
      console.log(student.firstName + ' ' + student.lastName);
    });

}());
