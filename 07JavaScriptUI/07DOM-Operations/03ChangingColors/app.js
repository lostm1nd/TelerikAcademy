window.onload = function() {
	'use strict';
	
	var textColorInput = document.getElementById('text'),
		backgroundColorInput = document.getElementById('background'),
		textarea = document.getElementsByTagName('textarea')[0];

	textColorInput.addEventListener('change', function() {
		textarea.style.color = textColorInput.value;
	}, false);

	backgroundColorInput.addEventListener('change', function() {
		textarea.style.backgroundColor = backgroundColorInput.value;
	}, false);
};