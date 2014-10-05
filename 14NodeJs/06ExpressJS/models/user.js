var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var userSchema = new Schema({
  name: String,
  email: String,
  password: String,
  registered: Date
});

userSchema.methods.validPassword = function (password) {
  return password === this.password;
};

var User = mongoose.model('User', userSchema);

module.exports = User;
