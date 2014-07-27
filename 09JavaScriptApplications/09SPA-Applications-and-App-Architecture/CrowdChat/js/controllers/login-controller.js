define(function() {
  'use strict';

  var appContext = null,
      $viewContainer = null;

  var isValidNikcname = function(nick) {
    if (typeof nick !== 'string') {
      return false;
    }

    if (nick.length < 2 && 14 < nick.length) {
      return false;
    }

    return true;
  };

  var enterChatBtnClick = function() {
    var nick = $viewContainer.find('#nick').val();

    if (isValidNikcname(nick)) {
      appContext.redirect('#/chat');
    } else {
      alert('Nickname must be between 2 and 14 symbols');
    }
  };

  var loadView = function() {
    $viewContainer.empty();
    $viewContainer.load('views/login-view.html');
    $viewContainer.on('click', '#login', enterChatBtnClick);
  };

  var init = function(app) {
    appContext = app;
    $viewContainer = app.$element();
    loadView();
  };

  return {
    init: init
  };
});
