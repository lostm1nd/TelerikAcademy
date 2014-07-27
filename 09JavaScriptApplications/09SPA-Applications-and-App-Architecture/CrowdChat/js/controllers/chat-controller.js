define(['jquery', 'mustache'], function($, Mustache) {
  'use strict';

  var POST_URL = 'http://crowd-chat.herokuapp.com/posts',
      $viewContainer = null;

  var loadView = function() {
    $viewContainer.empty();
    $viewContainer.load('views/chat-view.html');
  };

  var loadPosts = function() {
    $.when(
      $.getJSON(POST_URL),
      $.ajax({
        type: 'GET',
        url: 'templates/post.html',
        dataType: 'html'
      })
    )
    .then(function success(posts, template) {
      var rendered = Mustache.render(template[0], {posts: posts[0]});
      $viewContainer.find('#messages').empty();
      $viewContainer.find('#messages').append(rendered);
    }, function error(err) {
      console.log(err);
    });

     $viewContainer.find('#messages').scrollTop($viewContainer.find('#messages')[0].scrollHeight);
  };

  var onSendBtnClick = function() {
    var msg = $viewContainer.find('#chat').find('input').val();
    var nick = localStorage.getItem('Nickname');

    $.post(POST_URL, {
      text: msg,
      user: nick
    }, function success(msg) {
      loadPosts();
    }, 'json');

    $viewContainer.find('#chat').find('input').val('');
  };

  var init = function(app) {
    $viewContainer = app.$element();

    loadView();

    setInterval(loadPosts, 1500);

    $viewContainer.on('click', '#send', onSendBtnClick);
  };

  return {
    init: init
  };
});
