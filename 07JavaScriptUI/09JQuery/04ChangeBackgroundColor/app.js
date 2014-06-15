$(document).ready(function() {
	$('button').on('click', changeBackgroundColor);

	function changeBackgroundColor() {
		var color = $('input').val();

		$(document.body).css('background-color', color);
	}
});