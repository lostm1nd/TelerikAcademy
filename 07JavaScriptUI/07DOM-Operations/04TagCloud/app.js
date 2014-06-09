window.onload = function() {
	'use strict';

	var tags = [
	"cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css",
	"wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC",
	"ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript",
	"http", "http", "CMS"];

	document.querySelector('button').addEventListener('click', function() {

		var fontSizes = document.getElementsByTagName('input');
		generateTagCloud(fontSizes[0].value, fontSizes[1].value);

	}, false);

	function generateTagCloud(minFontSize, maxFontSize) {
		minFontSize = minFontSize || 16;
		maxFontSize = maxFontSize || 42;

		var sortedTags = sortTagsByFrequency(),
			fontStep = Math.floor((maxFontSize - minFontSize) / sortedTags.length);

		var container = document.createElement('div');
		container.id = 'tag-container';

		for (var i = 0; i < sortedTags.length; i+=1) {
			var div = document.createElement('div');
			div.innerHTML = sortedTags[i][1];
			div.style.fontSize = maxFontSize + 'px';
			div.style.padding = '6px';
			div.style.float = (i % 2 === 0) ? 'left' : 'right';
			container.appendChild(div);
			maxFontSize -= fontStep;
		}

		document.body.appendChild(container);
	}

	function sortTagsByFrequency() {
		var tagFrequency = {},
			tagSorter = [];

		tags.forEach(function(tag){
			if (tagFrequency[tag.toLowerCase()]) {
				tagFrequency[tag.toLowerCase()] += 1;
			} else {
				tagFrequency[tag.toLowerCase()] = 1;
			}
		});

		for (var tag in tagFrequency) {
			if(tagFrequency.hasOwnProperty(tag)) {
				tagSorter.push([tagFrequency[tag], tag]);
			}
		}

		tagSorter.sort(function(a, b) {
			return b[0] - a[0];
		});

		return tagSorter;
	}
};