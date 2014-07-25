describe('Testing Animal type', function() {
  it('should have the given name', function() {
    var animal = new Animal('generic', 'Rhine', 3);
    expect(animal.getName()).to.equal('Rhine');
  });
  it('should have the given age', function() {
    var animal = new Animal('generic', 'Rhine', 3);
    expect(animal.getAge()).to.equal(3);
  });
  it('should throw a TypeError when age is not a number', function() {
    expect(function() {
      new Animal('generic', 'Rhine', '12');
    }).to.throw(TypeError);
  });
  it('should throw a RangeError when age is float', function() {
    expect(function() {
      new Animal('generic', 'Rhine', 3.5);
    }).to.throw(RangeError);
  });
});
