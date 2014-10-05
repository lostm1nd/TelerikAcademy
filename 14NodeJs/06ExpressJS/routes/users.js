var router = require('express').Router();
var passport = require('passport');

router.get('/register', function (req, res) {
  res.render('users/register');
});

router.post('/register', passport.authenticate('local-register', {
  successRedirect: '/',
  failureRedirect: '/users/register'
}));

router.get('/login', function (req, res) {
  res.render('users/login');
});

router.post('/login', passport.authenticate('local-login', {
  successRedirect: '/',
  failureRedirect: '/users/login'
}));

module.exports = router;
