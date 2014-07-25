describe('Test the Cat type', function() {
  it('should be an instanceof Animal', function() {
    var cat = new Cat('Kino', 3);
    expect(cat).to.be.instanceof(Animal);
  });
  it('should have a property getType', function() {
    var cat = new Cat('Kino', 3);
    expect(cat).to.have.property('getType');
  });
  it('should have a type cat', function() {
    var cat = new Cat('Kino', 3);
    expect(cat.getType()).to.equal('cat');
  });
});
