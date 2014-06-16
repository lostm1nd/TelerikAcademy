function createCalendar(target, events) {
	'use strict';
	var bodyColor = 'rgb(255, 255, 255)',
		titleColor = 'rgb(204, 204, 204)',
		titleHoverColor = 'rgb(170, 170, 170)';

	var targetContainer = document.querySelector(target),
		docFragment = document.createDocumentFragment(),
		days = ['Sun', 'Mon', 'Tue', 'Thu', 'Fri', 'Sat'];

	for (var i = 0; i < 30; i+=1) {
		var div = document.createElement('div');
		div.setAttribute('class', 'box day-' + (i+1));
		div.style.width = '150px';
		div.style.height = '150px';
		div.style.border = '1px solid black';
		div.style.backgroundColor = '#fff';
		div.style.cssFloat = 'left';
		div.innerHTML = '<p style="background-color: ' + titleColor +'; text-align: center; margin-top: 0;">' +
						days[i%days.length] + ' ' + (i+1) + ' June 2014</p>';

		docFragment.appendChild(div);
	}

	targetContainer.appendChild(docFragment);

	events.forEach(function(ev) {
		var div = document.querySelector('.day-' + ev.date);
		div.innerHTML += '<p>' + ev.hour + ' ' + ev.title + '</p>';
	});

	var boxes = document.querySelectorAll('.box');
	var len = boxes.length;
	for (i = 0; i < len; i+=1) {

		boxes[i].addEventListener('mouseenter', onBoxHover);
		boxes[i].addEventListener('mouseleave', onBoxMouseOut);
		boxes[i].addEventListener('click', onBoxClick);
	}

	function onBoxHover(ev) {
		ev = event || window.event;

		var title = ev.target.firstChild,
			color = title.style.backgroundColor;

		if (color === titleColor){
			title.style.backgroundColor = titleHoverColor;
		}
	}

	function onBoxMouseOut(ev) {
		ev = event || window.event;

		var title = ev.target.firstChild,
			color = title.style.backgroundColor;

		// if the background is 7b7 then the
		// day is clicked and we do not want to
		// change the color when the mouse leaves
		if (color === titleHoverColor){
			title.style.backgroundColor = titleColor;
		}		
	}

	function onBoxClick(ev) {
		ev = event || window.event;

		var selected = document.querySelector('.selected');

		if (selected && selected !== ev.target) {
			var	selectedClassNames = selected.getAttribute('class');
			selectedClassNames = selectedClassNames.replace('selected', '');
			selected.style.backgroundColor = bodyColor;
			selected.firstChild.style.backgroundColor = titleColor;
			selected.setAttribute('class', selectedClassNames);
		}		

		var targetClassNames = ev.target.getAttribute('class'),
			currentBodyColor = ev.target.style.backgroundColor;

		// add a class so we know when there is a selected element
		ev.target.setAttribute('class', targetClassNames + ' selected');

		// if it is the default - highlight it
		// otherwise set the defaults - when a second click occurs
		if (currentBodyColor === bodyColor) {
			ev.target.style.backgroundColor = '#7b7';
			ev.target.firstChild.style.backgroundColor = '#7b7';
		} else {
			ev.target.style.backgroundColor = bodyColor;
			ev.target.firstChild.style.backgroundColor = titleHoverColor;
		}
		
	}
}