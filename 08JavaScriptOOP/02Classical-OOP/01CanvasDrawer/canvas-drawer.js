var CanvasDrawer = (function() {
  'use strict';

  var canvas,
      ctx2d;

  function CanvasDrawer(canvasID) {
    if (!(this instanceof CanvasDrawer)) {
      return new CanvasDrawer(canvasID);
    }

    canvas  = document.getElementById(canvasID);
    ctx2d = canvas.getContext('2d');
  }

  CanvasDrawer.prototype.Rect = function rect(x, y, width, height, fillColor, strokeColor) {
    ctx2d.fillStyle = fillColor || 'black';
    ctx2d.strokeStyle = strokeColor || 'yellow';

    ctx2d.beginPath();
    ctx2d.rect(x, y, width, height);
    ctx2d.fill();
    ctx2d.stroke();
  };

  CanvasDrawer.prototype.Circle = function circle(x, y, radius, fillColor, strokeColor) {
    ctx2d.fillStyle = fillColor || 'black';
    ctx2d.strokeStyle = strokeColor || 'yellow';

    ctx2d.beginPath();
    ctx2d.arc(x, y, radius, 0, 2*Math.PI, false);
    ctx2d.fill();
    ctx2d.stroke();
  };

  CanvasDrawer.prototype.Line = function line(x1, y1, x2, y2, strokeColor) {
    ctx2d.strokeStyle = strokeColor || 'yellow';

    ctx2d.beginPath();
    ctx2d.moveTo(x1, y1);
    ctx2d.lineTo(x2, y2);
    ctx2d.stroke();
  };

  return CanvasDrawer;
}());
