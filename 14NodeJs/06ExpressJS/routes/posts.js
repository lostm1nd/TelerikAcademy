var router = require('express').Router();
var Post = require('mongoose').model('Post');

router.get('/', function (req, res) {
  Post.find().exec(function (err, posts) {
    res.render('posts/all', {posts: posts});
  });
});

router.get('/create', isAuthorized, function (req, res) {
  res.render('posts/create');
});

router.post('/create', isAuthorized, function (req, res) {
  var newPost = new Post({
    title: req.body.title,
    text: req.body.text,
    published: Date.now(),
    author: req.session.passport.user,
  });

  newPost.save(function (err, post) {
    res.redirect('/posts');
  });
});

router.get('/:id', function (req, res) {
  Post.findById(req.params.id)
  .populate('author')
  .exec(function (err, post) {
    res.render('posts/details', {post: post});
  });
});

function isAuthorized(req, res, next) {
  if (req.isAuthenticated()) {
    return next();
  }

  res.redirect('/users/login');
}

module.exports = router;
