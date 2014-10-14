$(document).ready(function () {
  var counter = 0;
  var $addInitiative = $('#add-initiative');
  var $target = $('#you-want-me');

  $addInitiative.on('click', function (ev) {
    ev.preventDefault();
    createInitiativeElement().insertAfter($target);
  });

  function createInitiativeElement() {
    var select = [
      '<div class="form-group">',
        '<label for="select" class="col-md-4 control-label">Part of</label>',
        '<div class="col-md-4">',
          '<select class="form-control" name="initiatives[]">',
            '<option value="Software Academy">Software Academy</option>',
            '<option value="Algo Academy">Algo Academy</option>',
            '<option value="School Academy">School Academy</option>',
            '<option value="Kids Academy">Kids Academy</option>',
          '</select>',
        '</div>',
        '<div class="col-md-4">',
          '<select class="form-control" name="seasons[]">',
            '<option value="Started 2010">Started 2010</option>',
            '<option value="Started 2011">Started 2011</option>',
            '<option value="Started 2012">Started 2012</option>',
            '<option value="Started 2013">Started 2013</option>',
          '</select>',
        '</div>',
      '</div>'];

    var html = select.join('')
      .replace('initiatives[]', 'initiatives[' + counter + ']')
      .replace('seasons[]', 'seasons[' + counter + ']');

    counter += 1;

    return $(html);
  }
});
