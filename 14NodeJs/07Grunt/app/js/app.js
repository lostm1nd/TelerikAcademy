(function() {
  var Person, Robot, main, nav, pers, rbt,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  Person = (function() {
    function Person(name, age) {
      this.name = name;
      this.age = age;
    }

    Person.prototype.sayHello = function() {
      return alert('Hello, stranger. I am ' + this.name);
    };

    Person.prototype.grow = function() {
      return this.age += 1;
    };

    return Person;

  })();

  Robot = (function(_super) {
    __extends(Robot, _super);

    function Robot(name, age) {
      Person.call(this, name, age);
    }

    Robot.prototype.sayHello = function() {
      return alert('I am human also! My name is ' + this.name);
    };

    return Robot;

  })(Person);

  pers = new Person('John', 29);

  rbt = new Robot('Jenkins', 101);

  nav = document.getElementsByTagName('nav')[0];

  nav.addEventListener('click', function() {
    return alert(pers.sayHello());
  });

  main = document.getElementById('main');

  main.addEventListener('click', function() {
    return alert(rbt.sayHello());
  });

}).call(this);
