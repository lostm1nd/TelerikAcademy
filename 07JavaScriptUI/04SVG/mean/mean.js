(function() {
	'use strict';

	var svgNamespace = 'http://www.w3.org/2000/svg',
		container = document.getElementById('svg-container'),
		svg = createSvg(400, 600, svgNamespace),
		lettersAndCircles = [];

	// first circle
	lettersAndCircles.push(createCircle(200, 100, 80, '#3e3f37', svgNamespace));
	lettersAndCircles.push(createLeaf(180, 110, '#5eb14a', svgNamespace));

	// second circle
	lettersAndCircles.push(createCircle(200, 180, 80, '#282827', svgNamespace));
	var express = createText(200, 180, '#fff', '36', 'Arial', 'normal', 'express', svgNamespace);
	express.setAttribute('text-anchor', 'middle');
	express.setAttribute('letter-spacing', 2);
	lettersAndCircles.push(express);

	// third circle - angularJS
	lettersAndCircles.push(createCircle(200, 260, 80, '#e23337', svgNamespace));
	lettersAndCircles.push(createHexagon(200, 300, 80, 90, '#b7aaa9', svgNamespace));
	lettersAndCircles.push(createHexagon(200, 300, 74, 86, '#e23337', svgNamespace));
	lettersAndCircles.push(createTriangle(200, 220, 70, 60, '#b3b3b3', svgNamespace));
	lettersAndCircles.push(createTriangle(200, 240, 40, 30, '#e23337', svgNamespace));

	// forth circle - nodeJS
	lettersAndCircles.push(createCircle(200, 340, 80, '#8ec74e', svgNamespace));
	lettersAndCircles.push(createNodeLogo(150, 320, '#47493f', '#fff', svgNamespace));

	// text
	lettersAndCircles.push(createText(30, 130, '#3e3f37', 60, 'Arial', 'bold', 'M', svgNamespace));
	lettersAndCircles.push(createText(30, 210, '#282827', 60, 'Arial', 'bold', 'E', svgNamespace));
	lettersAndCircles.push(createText(30, 290, '#e23337', 60, 'Arial', 'bold', 'A', svgNamespace));
	lettersAndCircles.push(createText(30, 370, '#8ec74e', 60, 'Arial', 'bold', 'N', svgNamespace));

	lettersAndCircles.forEach(function(svgElement) {
		svg.appendChild(svgElement);
	});

	container.appendChild(svg);

	function createSvg(width, height, namespace) {
		var svg = document.createElementNS(namespace, 'svg');

		svg.setAttribute('width', width);
		svg.setAttribute('height', height);

		return svg;
	}

	function createCircle(x, y, radius, fill, namespace) {
		var circle = document.createElementNS(namespace, 'circle');

		circle.setAttribute('cx', x);
		circle.setAttribute('cy', y);
		circle.setAttribute('r', radius);
		circle.setAttribute('fill', fill);

		return circle;
	}

	function createLeaf(x, y, fill, namespace) {
		var leaf = document.createElementNS(namespace, 'path');

		leaf.setAttribute('fill', fill);
		leaf.setAttribute('d', 'M' + x + ' ' + y +
			' Q ' + (x-15) + ' ' + (y-10) + ' ' + (x+20) + ' ' + (y-50) +
			' Q ' + (x+55) + ' ' + (y-10) + ' ' + (x+40) + ' ' + y);

		return leaf;
	}

	function createHexagon(startX, startY, width, height, fill, namespace) {
		var hexagon = document.createElementNS(namespace, 'polygon');

		hexagon.setAttribute('fill', fill);
		hexagon.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-width/2) + ',' + (startY-15) + ' ' + (startX-2-width/2) + ',' + (startY-(height-25)) + ' ' +
			startX + ',' + (startY-height)+ ' ' +(startX+2+width/2) + ',' + (startY-(height-25))+ ' ' +
			(startX+width/2) + ',' + (startY-15));

		return hexagon;
	}

	function createTriangle(topX, topY, width, height, fill, namespace) {
		var triangle = document.createElementNS(namespace, 'polygon');

		triangle.setAttribute('fill', fill);
		triangle.setAttribute('points', topX + ',' + topY + ' ' +
							(topX+width/2) + ',' + (topY+height) + ' ' +
							(topX-width/2) + ',' + (topY+height));

		return triangle;
	}

	function createNodeLogo(startX, startY, color1, color2, namespace) {
		var letterN = document.createElementNS(namespace, 'polyline'),
			letterO = document.createElementNS(namespace, 'polyline'),
			letterD = document.createElementNS(namespace, 'polyline'),
			letterE = document.createElementNS(namespace, 'polyline'),
			group = document.createElementNS(namespace, 'g');

		letterN.setAttribute('fill', color1);
		letterN.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-10) + ',' + (startY+5) + ' ' + (startX-10) + ',' + (startY+25) + ' ' +
			(startX-3) + ',' + (startY+20) + ' ' + (startX-3) + ',' + (startY+10) + ' ' +
			startX + ',' + (startY+8) + ' ' + (startX+3) + ',' + (startY+10) + ' ' +
			(startX+3) + ',' + (startY+20) + ' ' + (startX+10) + ',' + (startY+25) + ' ' +
			(startX+10) + ',' + (startY+5) + ' ' + startX + ',' + startY);
		group.appendChild(letterN);

		// move the x position so that the
		// next letters starts next to the first
		startX += 30;
		letterO.setAttribute('fill', color2);
		letterO.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-10) + ',' + (startY+5) + ' ' + (startX-10) + ',' + (startY+20) + ' ' +
			(startX) + ',' + (startY+25) + ' ' + (startX+10) + ',' + (startY+20) + ' ' +
			(startX+10) + ',' + (startY+5) + ' ' + startX + ',' + startY);
		group.appendChild(letterO);

		startX += 30;
		letterD.setAttribute('fill', color1);
		letterD.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-10) + ',' + (startY+5) + ' ' + (startX-10) + ',' + (startY+20) + ' ' +
			(startX) + ',' + (startY+25) + ' ' + (startX+10) + ',' + (startY+20) + ' ' +
			(startX+10) + ',' + (startY-10) + ' ' + (startX+5) + ',' + (startY-12) + ' ' +
			(startX+5) + ',' + (startY+5) + ' ' + startX + ',' + startY);
		group.appendChild(letterD);
		group.appendChild(regularHexagon(startX, startY+7, 10, 12, '#8ec74e', namespace));

		startX += 30;
		letterE.setAttribute('fill', color1);
		letterE.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-10) + ',' + (startY+5) + ' ' + (startX-10) + ',' + (startY+20) + ' ' +
			(startX) + ',' + (startY+25) + ' ' + (startX+5) + ',' + (startY+20) + ' ' +
			(startX-4) + ',' + (startY+15) + ' ' + (startX-4) + ',' + (startY+10) + ' ' +
			startX + ',' + (startY+7) + ' ' + (startX+5) + ',' + (startY+10) + ' ' +
			(startX+5) + ',' + (startY+15) + ' ' + (startX+10) + ',' + (startY+10) + ' ' +
			(startX+10) + ',' + (startY+5) + ' ' + startX + ',' + startY);
		group.appendChild(letterE);
		group.appendChild(regularHexagon(startX, startY+8, 6, 7, '#fff', namespace));

		return group;
	}

	function regularHexagon(startX, startY, width, height, color, namespace) {
		var hex = document.createElementNS(namespace, 'polygon');

		hex.setAttribute('fill', color);
		hex.setAttribute('points', startX + ',' + startY + ' ' +
			(startX-width/2) + ',' + (startY+height/3) + ' ' +
			(startX-width/2) + ',' + (startY+2*height/3) + ' ' +
			(startX) + ',' + (startY+height) + ' ' +
			(startX+width/2) + ',' + (startY+2*height/3) + ' ' +
			(startX+width/2) + ',' + (startY+height/3) + ' ' + startX + ',' + startY);

		return hex;
	}

	function createText(x, y, color, size, font, weight, text, namespace) {
		var svgText = document.createElementNS(namespace, 'text'),
			letter = document.createTextNode(text);

		svgText.setAttribute('x', x);
		svgText.setAttribute('y', y);
		svgText.setAttribute('fill', color);
		svgText.setAttribute('font-size', size);
		svgText.setAttribute('font-family', font);
		svgText.setAttribute('font-weight', weight);
		svgText.appendChild(letter);

		return svgText;
	}
}());