var LocalStrategy = require('passport-local').Strategy;
var User = require('mongoose').model('User');

module.exports = function (passport) {
  passport.serializeUser(function (user, done) {
    done(null, user.id);
  });

  passport.deserializeUser(function (id, done) {
    User.findById(id, function (err, user) {
      done(err, user);
    });
  });

  passport.use('local-register', new LocalStrategy({
    usernameField: 'email',
    passwordField: 'password',
    passReqToCallback: true
  }, function (req, email, password, done) {
    User.findOne({email: email}, function (err, user) {
      if (err) {
        return done(err);
      }

      if (user) {
        return done(null, false, { message: 'Email already in use' });
      }

      var newUser = new User({
        name: req.body.name,
        email: email,
        password: password,
        registered: Date.now()
      });

      newUser.save(function (err, user) {
        if (err) {
            throw err;
        }

        return done(null, user);
      });
    });
  }));

  passport.use('local-login', new LocalStrategy({
    usernameField: 'email',
    passwordField: 'password',
  }, function (email, password, done) {
    User.findOne({email: email}, function (err, user) {
      if (err) {
        return done(err);
      }

      if (!user) {
        return done(null, false, { message: 'Incorrect email' });
      }

      if (!user.validPassword(password)) {
        return done(null, false, { message: 'Incorrect password' });
      }

      return done(null, user);
    });
  }));
};
