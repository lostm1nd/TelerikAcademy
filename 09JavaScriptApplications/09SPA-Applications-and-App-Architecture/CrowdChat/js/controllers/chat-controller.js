define(['jquery', 'q', 'mustache'], function($, Q, Mustache) {
  'use strict';

  var POST_URL = 'http://crowd-chat.herokuapp.com/posts',
      $viewContainer = null;

  var loadView = function() {
    $viewContainer.empty();
    $viewContainer.load('views/chat-view.html');
  };

  var getPosts = function() {
    var deferred = Q.defer();

    $.getJSON(POST_URL, function(posts) {
      deferred.resolve(posts);
    });

    return deferred.promise;
  };

  var loadPosts = function(posts) {
    $.get('templates/post.html')
      .then(function success(template) {
      var rendered = Mustache.render($(template).html(), {posts: posts});

      $viewContainer.empty();
      $viewContainer.find('#messages').append(rendered);
    }, function error(err) {
      console.log(err);
    });
  };

  var init = function(app) {
    $viewContainer = app.$element();
    loadView();
    getPosts()
      .then(function success(posts) {
        loadPosts(posts);
      }, function error(err) {
        console.log(err);
      });
  };

  return {
    init: init
  };
});
