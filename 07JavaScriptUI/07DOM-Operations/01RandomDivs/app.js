window.onload = function() {
	'use strict';

	var bodyHeight = getDocHeight(),
		bodyWidth = getDocWidth(),
		startButton = document.getElementsByTagName('button')[0];

	startButton.addEventListener('click', function() {
		var count = document.getElementById('count').value;
		generateRandomDivs(count);
	}, false);

	function generateRandomDivs(count) {
		var container = document.createElement('div');

		for (var i = 0; i < count; i++) {
			var div = document.createElement('div'),
				span = document.createElement('span'),
				width = getRandomInt(20, 100),
				height = getRandomInt(20, 100);

			div.style.width =  width + 'px';
			div.style.height =  height + 'px';
			div.style.position = 'absolute';
			div.style.left = (getRandomInt(0, bodyWidth) - width) + 'px';
			div.style.top = (getRandomInt(0, bodyHeight) - height) + 'px';
			div.style.backgroundColor = getRandomRgbColor();
			div.style.color = getRandomRgbColor();
			div.style.borderWidth = getRandomInt(0, 20) + 'px';
			div.style.borderRadius = getRandomInt(0, 50) + 'px';
			div.style.borderColor = getRandomRgbColor();
			div.style.borderStyle = 'solid';

			span.innerHTML = 'div';
			div.appendChild(span);
			container.appendChild(div);
		}

		document.body.appendChild(container);
	}
};