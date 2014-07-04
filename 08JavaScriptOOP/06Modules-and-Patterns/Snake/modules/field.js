define(function() {
  'use strict';

  var brickSize = 20,
      fieldWidth,
      fieldHeight;

  function setBounds(width, height) {
    fieldWidth = width;
    fieldHeight = height;
  }

  function drawField(ctx) {
    var bricksPerWall = fieldWidth / brickSize,
        x = 0,
        y = 0;

    ctx.fillStyle = '#78c355';
    ctx.fillRect(0, 0, fieldWidth, fieldHeight);

    ctx.fillStyle = '#b6482f';
    ctx.stokeStyle = '#612619';

    // vertical walls
    for (var i = 0; i < bricksPerWall; i += 1) {
      ctx.fillRect(0, y, brickSize, brickSize);
      ctx.strokeRect(0, y, brickSize, brickSize);

      ctx.fillRect(fieldWidth - brickSize, y, brickSize, brickSize);
      ctx.strokeRect(fieldWidth - brickSize, y, brickSize, brickSize);
      y += brickSize;
    }

    // horizontal wall
    for (var j = 0; j < bricksPerWall; j += 1) {
      ctx.fillRect(x, 0, brickSize, brickSize);
      ctx.strokeRect(x, 0, brickSize, brickSize);

      ctx.fillRect(x, fieldHeight - brickSize, brickSize, brickSize);
      ctx.strokeRect(x, fieldHeight - brickSize, brickSize, brickSize);
      x += brickSize;
    }
  }

  return {
    width: fieldHeight,
    height: fieldHeight,
    setBounds: setBounds,
    draw: drawField
  };

});
