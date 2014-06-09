window.onload = function() {
	var startButton = document.getElementsByTagName('button')[0],
		bodyHeight = getDocHeight(),
		bodyWidth = getDocWidth(),
		centerX = bodyWidth / 2,
		centerY = bodyHeight / 2,
		radius = 200;

	startButton.addEventListener('click', function() {
		var count = document.getElementById('count').value;
		generateDivsOnCirclePerimeter(count);
		rotateDivs();
	}, false);


	function generateDivsOnCirclePerimeter(count) {
		var container = document.createElement('div'),
			initialAngle = 0;

		for (var i = 0; i < count; i++) {
			var div = document.createElement('div'),
				width = getRandomInt(20, 50),
				height = getRandomInt(20, 50);

			div.style.width =  width + 'px';
			div.style.height =  height + 'px';
			div.style.position = 'absolute';
			div.style.left =  centerX + (radius*Math.cos(initialAngle)) + 'px';
			div.style.top =  centerY + (radius*Math.sin(initialAngle)) + 'px';
			div.style.backgroundColor = getRandomRgbColor();
			div.style.color = getRandomRgbColor();
			div.style.borderWidth = getRandomInt(0, 20) + 'px';
			div.style.borderRadius = getRandomInt(0, 50) + 'px';
			div.style.borderColor = getRandomRgbColor();
			div.style.borderStyle = 'solid';
			div.dataset.angle = initialAngle;

			container.appendChild(div);

			// get initialAngle in radians
			initialAngle += (360 / count) * (Math.PI / 180);
		}

		document.body.appendChild(container);
	}

	function rotateDivs() {
		var allDivs = document.getElementsByTagName('div'),
			divCount = allDivs.length;

		// ignore the first div
		// it is the container
		for (var i = 1; i < divCount; i++) {
			var divAngle = parseFloat(allDivs[i].dataset.angle),
				newAngle = divAngle + 0.02;

			allDivs[i].dataset.angle = newAngle;

			allDivs[i].style.left =  centerX + (radius*Math.cos(newAngle)) + 'px';
			allDivs[i].style.top =  centerY + (radius*Math.sin(newAngle)) + 'px';
		}

		setTimeout(rotateDivs, 100);
	}
};