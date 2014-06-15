$(document).ready(function() {
	function insertBefore(target, newElement) {
		$(target).before($(newElement));
	}

	function insertAfter(target, newElement) {
		$(target).after($(newElement));
	}

	var box = document.getElementById('box'),
		circle = document.createElement('div');

	circle.style.width = '100px';
	circle.style.height = '100px';
	circle.style.backgroundColor = 'green';
	circle.style.borderRadius = '50%';

	setTimeout(function() {
		insertBefore(box, circle);
		setTimeout(function() {
			insertAfter(box, circle);
		}, 1500);
	}, 1500);
});