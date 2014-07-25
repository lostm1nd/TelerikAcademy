var Dog = (function() {
  'use strict';

  function Dog(name, age) {
    Animal.call(this, 'dog', name, age);
  }

  Dog.prototype = Object.create(Animal.prototype);
  Dog.prototype.constructor = Dog;

  return Dog;
}());
