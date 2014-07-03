define(['field'], function(field) {
  'use strict';

  var food = {},
      foodColor = '#ddccaa',
      foodAvailable = false;

  function generateFood(canvasCtx, size) {
    if (!foodAvailable) {

      // trying to simulate a 10x10 grid
      // thats is why I want the food to
      // appear at coordinates divisible by 10
      food.x = getRandomInt(3, 46) * 10;
      food.y = getRandomInt(3, 46) * 10;
      foodAvailable = true;
    }

    canvasCtx.fillStyle = foodColor;
    canvasCtx.fillRect(food.x, food.y, size, size);
  }

  function eatFood() {
    foodAvailable = false;
  }

  function getRandomInt(min, max) {
    return Math.floor(Math.random() *
      (max - min + 1)) + min;
  }

  return {
    position: food,
    generate: generateFood,
    eat: eatFood
  };

});
