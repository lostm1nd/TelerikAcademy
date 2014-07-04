define(['snake'], function(snake) {
  'use strict';

  function handleInput(ev) {
    // left - 37, up - 38
    // right - 39, down - 40
    if (ev.keyCode === 37 && snake.getDirection() !== 'right') {
      snake.setDirection('left');
    } else if (ev.keyCode === 38 && snake.getDirection() !== 'down') {
      snake.setDirection('up');
    } else if (ev.keyCode === 39 && snake.getDirection() !== 'left') {
      snake.setDirection('right');
    } else if (ev.keyCode === 40 && snake.getDirection() !== 'up') {
      snake.setDirection('down');
    }
  }

  return {
    handleInput: handleInput
  };

});
