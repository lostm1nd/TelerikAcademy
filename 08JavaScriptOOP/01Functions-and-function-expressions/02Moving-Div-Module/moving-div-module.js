var MOVING_DIV_MODULE = (function() {
  'use strict';

  var divs = [],
      div = document.createElement('div'),
      ellipseCenterX = 150,
      ellipseCenterY = 150,
      ellipseX = 100,
      ellipseY = 40;

  div.style.width = '50px';
  div.style.height = '50px';
  div.style.position = 'absolute';

  function add(movement) {
    var clone = div.cloneNode(true);

    if (movement === 'rect') {
      clone.style.top = '50px';
      clone.style.left = '50px';
      clone.setAttribute('data-direction', 'right');
    } else {
      clone.setAttribute('data-angle', 0);
    }

    clone.className = movement;
    clone.style.backgroundColor = getRandomRgbColor();
    clone.style.border = '2px solid ' + getRandomRgbColor();

    document.body.appendChild(clone);

    divs.push(clone);
  }

  function engine() {
    for (var i = 0; i < divs.length; i+=1) {
      if (divs[i].className === 'rect') {
        rectMovement(divs[i]);
      } else {
        ellipseMovement(divs[i]);
      }
    }
  }

  function rectMovement(element) {
    // end point for moving right x:150 y:50
    // start moving down
    if (element.style.left === '150px' && element.style.top === '50px') {
      element.setAttribute('data-direction', 'down');
    }

    // end point for moving down x:150 y:150
    // start moving left
    if (element.style.left === '150px' && element.style.top === '150px') {
      element.setAttribute('data-direction', 'left');
    }

    // end point for moving left x:50 y:150
    // start moving up
    if (element.style.left === '50px' && element.style.top === '150px') {
      element.setAttribute('data-direction', 'up');
    }

    // end point for moving up x:50 y:50
    // back to start position - start moving right again
    if (element.style.left === '50px' && element.style.top === '50px') {
      element.setAttribute('data-direction', 'right');
    }

    var currentTop = parseInt(element.style.top, 10),
        currentLeft = parseInt(element.style.left, 10) ;

    switch (element.getAttribute('data-direction')) {
      case 'right':
        currentLeft += 2;
        break;
      case 'down':
        currentTop += 2;
        break;
      case 'left':
        currentLeft -= 2;
        break;
      case 'up':
        currentTop -= 2;
        break;
    }

    element.style.top = currentTop + 'px';
    element.style.left = currentLeft + 'px';
  }

  function ellipseMovement(element) {
    var angle = parseFloat(element.getAttribute('data-angle')),
        newAngle = angle + 0.05;

    element.setAttribute('data-angle', newAngle);

    element.style.left = ellipseCenterX + (ellipseX * Math.cos(newAngle)) + 'px';
    element.style.top = ellipseCenterY + (ellipseY * Math.sin(newAngle)) + 'px';
  }

  setInterval(engine, 60);

  return {
    add: add
  };

}());
