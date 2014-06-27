var CONSOLE_MODULE = (function() {
  'use strict';

  function writeLine() {
    if (arguments.length === 1) {
      singleArgumentHandler(arguments[0]);
    } else if (arguments.length > 1) {
      multripleArgumentsHandler(Array.prototype.slice.call(arguments));
    }
  }

  function singleArgumentHandler(arg) {
    if (typeof arg === 'string' && arg.toLowerCase().indexOf('error') !== -1) {
      console.error(arg);
    } else {
      console.log(arg);
    }
  }

  function multripleArgumentsHandler(args) {
    var text = args[0];

    for (var i = 1; i < args.length; i+=1) {
      var pattern = new RegExp('\\{' +(i-1) +'}', 'g');
      text = text.replace(pattern, args[i]);
    }

    singleArgumentHandler(text);

  }

  return {
    writeLine: writeLine
  };

}());
