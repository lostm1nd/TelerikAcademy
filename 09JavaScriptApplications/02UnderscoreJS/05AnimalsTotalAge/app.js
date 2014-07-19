// By a given array of animals,
// find the total animals age

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

  var totalAge = _.chain(animals)
                  .pluck('age')
                  .reduce(function(total, next) {
                    return total + next;
                  }, 0).value();

  console.log(totalAge);
}());
