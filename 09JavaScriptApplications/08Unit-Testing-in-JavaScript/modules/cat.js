var Cat = (function() {
  'use strict';

  function Cat(name, age) {
    Animal.call(this, 'cat', name, age);
  }

  Cat.prototype = Object.create(Animal.prototype);
  Cat.prototype.constructor = Cat;

  return Cat;
}());
