define(['jquery', 'q', 'mustache', 'login'], function($, Q, Mustache, loginController) {
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
    $.ajax({
      type: 'GET',
      url: 'templates/post.html',
      dataType: 'html'
    })
    .then(function success(template) {
      var rendered = Mustache.render(template, {posts: posts});
      $viewContainer.find('#messages').empty();
      $viewContainer.find('#messages').append(rendered);
    }, function error(err) {
      console.log(err);
    });

  };

  var onSendBtnClick = function() {
    var msg = $viewContainer.find('#chat').find('input').val();
    var nick = loginController.getNick();

    $.post(POST_URL, {
      text: msg,
      user: nick
    }, function success(msg) {
      getPosts()
      .then(function success(posts) {
        loadPosts(posts);
      }, function error(err) {
        console.log(err);
      });
    }, 'json');

    $viewContainer.find('#chat').find('input').val('');
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

    $viewContainer.on('click', '#send', onSendBtnClick);
  };

  return {
    init: init
  };
});
