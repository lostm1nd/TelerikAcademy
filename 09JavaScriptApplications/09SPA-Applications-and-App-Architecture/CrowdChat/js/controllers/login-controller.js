define(function() {
  'use strict';

  var $viewContainer = null;

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
      window.location('#/chat');
    } else {
      alert('Nickname must be between 2 and 14 symbols');
    }
  };

  var loadView = function() {
    $viewContainer.empty();
    $viewContainer.load('views/login-view.html');
    $viewContainer.on('click', '#login', enterChatBtnClick);
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
  };

  return {
    init: init
  };
});
