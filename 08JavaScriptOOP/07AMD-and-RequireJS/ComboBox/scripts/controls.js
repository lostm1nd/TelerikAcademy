define(['jquery', 'handlebars'], function($) {
  'use strict';

  // Hidden utility function
  function createComboBox(html) {
    var $filter = $('<div>').append(html).find('div'),
        $comboBox = $('<div>').attr('data-state', 'collapsed').append($filter),
        $comboBoxItems = $comboBox.children('div');

    // Start from the 1st index since we want
    // the element at index 0 to be visible.
    for (var i = 1; i < $comboBoxItems.length; i+=1) {
      $($comboBoxItems[i]).hide();
    }

    $comboBoxItems.on('click', function() {
      var $parent = $(this).parent();

      if ($parent.attr('data-state') === 'collapsed') {
        $parent.children('div').show();
        $parent.attr('data-state', 'open');
      } else {
        $parent.children('div').hide();
        $(this).show();
        $parent.attr('data-state', 'collapsed');
      }
    });

    // Using the pure js to get the outer
    // html since jquery has no such option.
    return $comboBox;
  }

  // Exposed function constructor
  var ComboBox = (function() {
    var _data;

    function ComboBox(data) {
      if (!(this instanceof ComboBox)) {
        return new ComboBox(data);
      }

      _data = data;
    }

    ComboBox.prototype.render = function render(templateSource) {
      var template = Handlebars.compile(templateSource),
          html = template({people: _data}),
          $comboBox = createComboBox(html);

      return $comboBox;
    };

    return ComboBox;
  }());

  return {
    ComboBox: ComboBox
  };

});
