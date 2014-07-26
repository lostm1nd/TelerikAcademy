(function($) {
  'use strict';

  var app = Sammy('#main', function() {
    this.get('#/', function(context) {
      context.$element().load('templates/login-form.html');
    });
  });

  $(function() {
    app.run('#/');
  });

}(jQuery));
