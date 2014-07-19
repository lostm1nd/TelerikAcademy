// Write a function that by a given array of animals,
// groups them by species and sorts them by number of years

(function() {
  'use strict';

  var animal = {
    init: function(species, age) {
      this.species = species;
      this.age = age;
      return this;
    }
  };

  var animals = [
    Object.create(animal).init('cat', 4),
    Object.create(animal).init('dog', 7),
    Object.create(animal).init('cat', 3),
    Object.create(animal).init('dog', 2),
    Object.create(animal).init('lion', 3),
    Object.create(animal).init('cat', 8),
    Object.create(animal).init('tiger', 1),
    Object.create(animal).init('dog', 2)
  ];

  // using the built-in sort method
  // since _.sortBy returns a copy
  // of the array but we need to sort
  // the array in place
  _.chain(animals)
    .groupBy('species')
    .each(function(group) {
      group.sort(function(a, b) {
        return a.age - b.age;
      });
    })
    .tap(function(all) {
      console.log(all);
    });

}());
