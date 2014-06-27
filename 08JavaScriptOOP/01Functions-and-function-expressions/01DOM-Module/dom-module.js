var DOM_MODULE = (function() {
  'use strict';

  var elementBuffer = {};

  function appendChild(element, parentSelector) {
    var parent = document.querySelector(parentSelector);
    parent.appendChild(element);
  }

  function removeChild(parentSelector, childSelector) {
    var parent = document.querySelector(parentSelector),
        child = document.querySelector(childSelector);

    parent.removeChild(child);
  }

  function addHandler(selector, eventType, handlerFunc) {
    var elements = document.querySelectorAll(selector),
        length = elements.length;

    for (var i = 0; i < length; i+=1) {
      elements[i].addEventListener(eventType, handlerFunc);
    }
  }

  function appendToBuffer(selector, elementToAppend) {
    if (elementBuffer[selector]) {
      elementBuffer[selector].push(elementToAppend);
    } else {
      elementBuffer[selector] = [elementToAppend];
    }

    if (elementBuffer[selector].length === 100) {
      var docFrag = document.createDocumentFragment();

      for (var i = 0; i < elementBuffer[selector].length; i+=1) {
        docFrag.appendChild(elementBuffer[selector][i]);
      }

      document.querySelector(selector).appendChild(docFrag);
      elementBuffer[selector] = [];
    }
  }

  function cssSelector(selector) {
    return document.querySelector(selector);
  }

  return {
    appendChild: appendChild,
    removeChild: removeChild,
    addHandler: addHandler,
    appendToBuffer: appendToBuffer,
    cssSelector: cssSelector
  };

}());
