require.config({
  paths: {
    'jquery': '../lib/jquery-2.1.1.min',
    'sammy': '../lib/sammy',
    'mustache': '..lib/mustache',
    'q': '../lib/q',
    'login': 'controllers/login-controller',
    'chat': 'controllers/chat-controller'
  }
});

require(['jquery', 'sammy', 'login', 'chat'], function($, sammy, loginController, chatController) {

  var app = sammy('#main', function() {

    this.get('#/', function(context) {
      loginController.init('#main');
    });

    this.get('#/chat', function(context) {
      chatController.init('#main');
    });

  });

  $(function() {
    app.run('#/');
  });

});
