define(['food', 'score', 'field'], function(food, score, field) {
  'use strict';

  var snake = [],
      isSnakeAlive = true,
      direction = 'right',
      snakeColor = '#186600',
      snakeBodySize;

  // The snake starts with the defined body
  // length. We need to push the coordinates
  // of each snake block so we can then draw
  // them on the canvas
  function init(snakeLength, segmentSize, startX, startY) {
    snakeBodySize = segmentSize;

    for (var i = 1; i <= snakeLength; i+=1) {
      snake.push({
        x: startX - (snakeLength - i) * snakeBodySize,
        y: startY
      });
    }
  }

  function getHead() {
    var headX = snake[snake.length - 1].x,
        headY = snake[snake.length - 1].y;

    return {
      x: headX,
      y: headY
    };
  }

  function getDirection() {
    return direction;
  }

  function setDirection(newDirection) {
    direction = newDirection;
  }

  function updateSnake(canvasCtx) {
    var head = getHead();

    if (!isSnakeInFieldBounds() || snakeBitesItself()) {
      isSnakeAlive = false;
    }

    if (snakeEatsFood()) {
      food.eat();
      snake.unshift({
        x: head.x,
        y: head.y
      });

      score.increaseScore();
    }

    if (isSnakeAlive) {
      moveSnake();
    }

    drawSnake(canvasCtx);
  }

  function drawSnake(canvasCtx) {
    var bodyX,
        bodyY;

    canvasCtx.fillStyle = snakeColor;

    for (var i = snake.length - 1; i >= 0; i-=1) {
      bodyX = snake[i].x;
      bodyY = snake[i].y;

      canvasCtx.fillRect(bodyX, bodyY, snakeBodySize, snakeBodySize);
    }
  }

  function isSnakeInFieldBounds() {
    var head = getHead();

    if (head.x <= 20 || head.x >= 480 - snakeBodySize ||
        head.y <= 20 || head.y >= 480 - snakeBodySize) {
      return false;
    }

    return true;
  }

  function snakeBitesItself() {
    var head = getHead();

    for (var i = 0; i < snake.length - 1; i+=1) {
      if (head.x === snake[i].x && head.y === snake[i].y) {
        return true;
      }
    }

    return false;
  }

  function moveSnake() {
    var head = getHead(),
        newHead = snake.shift();

    if (direction === 'left') {
      newHead.x = head.x - snakeBodySize;
      newHead.y = head.y;
    } else if (direction === 'up') {
      newHead.x = head.x;
      newHead.y = head.y - snakeBodySize;
    } else if (direction === 'right') {
      newHead.x = head.x + snakeBodySize;
      newHead.y = head.y;
    } else if (direction === 'down') {
      newHead.x = head.x;
      newHead.y = head.y + snakeBodySize;
    }

    snake.push(newHead);
  }

  function snakeEatsFood() {
    var head = getHead();

    if (head.x === food.position.x && head.y === food.position.y) {
      return true;
    }

    return false;
  }

  return {
    init: init,
    update: updateSnake,
    getDirection: getDirection,
    setDirection: setDirection,
    isSnakeAlive: isSnakeAlive
  };

});
