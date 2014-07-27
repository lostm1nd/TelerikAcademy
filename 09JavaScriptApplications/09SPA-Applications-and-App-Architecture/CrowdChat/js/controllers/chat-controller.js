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
    $.get('templates/posts.mst', function(template) {
      var rendered = Mustache.render(template, {posts: posts});

      $viewContainer.empty();
      $viewContainer.find('#messages').append(rendered);
    });
  };

  var init = function(elementId) {
    if (!elementId) {
      throw new Error('Id selector must be provided.');
    }

    if (!$(elementId)) {
      throw new Error('The provided id is not valid.');
    }

    $viewContainer = $(elementId);
    loadView();
    var posts = getPosts();
    loadPosts(posts);
  };

  return {
    init: init
  };
});
