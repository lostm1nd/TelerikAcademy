var Animal = (function() {
  'use strict';

  var AnimalTypes = ['Cat', 'Dog', 'Horse', 'Chicken'];

  function Animal(type, name, age) {
    this._type = type;
    this.setName(name);
    this.setAge(age);
  }

  Animal.prototype.setType = function(type) {
    if (AnimalTypes.indexOf(type) < 0) {
      throw new TypeError('Animal types are: Cat, Dog, Horse, Chicken.');
    }

    this._type = type;
  };

  Animal.prototype.setName = function(name) {
    if (typeof name !== 'string') {
      throw new TypeError('Name must be a string.');
    }

    this._name = name;
  };

  Animal.prototype.setAge = function(age) {
    if (typeof age !== 'number') {
      throw new TypeError('Name must be a number.');
    }

    if (parseInt(age, 10) !== age || age < 0) {
      throw new RangeError('Number must be a positive integer.');
    }

    this._age = age;
  };

  Animal.prototype.getName = function getName() {
    return this._name;
  };

  Animal.prototype.getAge = function getAge() {
    return this._age;
  };

  Animal.prototype.getType = function getType() {
    return this._type;
  };

  return Animal;
}());
