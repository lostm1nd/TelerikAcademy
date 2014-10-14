$(document).ready(function () {
  $editBtn = $('#edit-btn');
  $saveBtn = $('#save-btn');
  $cancelBtn = $('#cancel-btn');
  $inputs = $('#profile-form').find('input');

  $editBtn.on('click', function (ev) {
    ev.preventDefault();

    $inputs.each(function (index, input) {
      $(input).prop('disabled', false);
    });

    $editBtn.addClass('hidden');
    $saveBtn.removeClass('hidden');
    $cancelBtn.removeClass('hidden');
  });
});
