require.config({
  paths: {
    'snake': 'modules/snake',
    'field': 'modules/field',
    'food': 'modules/food',
    'score': 'modules/score',
    'input': 'modules/input-handler'
  }
});

require(['snake', 'field', 'input', 'food'], function(snake, field, input, food) {

  var canvas = document.getElementById('game'),
      ctx = canvas.getContext('2d');

  window.addEventListener('keydown', input.handleInput, false);
  field.setBounds(canvas.width, canvas.height);
  snake.init(5, 10, canvas.width/2, canvas.height/2);

  setInterval(function() {
    field.draw(ctx);
    food.generate(ctx, 10);
    snake.update(ctx);
  }, 100);

});
