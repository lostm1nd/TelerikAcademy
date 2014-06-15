$(document).ready(function() {
	var lectures = [{
		title: 'Course Introduction',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 14:00, 29-May-2014'
	}, {
		title: 'DOM',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 14:00, 29-May-2014'
	}, {
		title: 'HTML5 Canvas',
		date1: 'Thu 18:00, 29-May-2014',
		date2: 'Fri 14:00, 30-May-2014'
	}, {
		title: 'KineticJS',
		date1: 'Thu 18:00, 29-May-2014',
		date2: 'Fri 14:00, 30-May-2014'
	}, {
		title: 'SVG & RaphaelJS',
		date1: 'Wed 18:00, 04-May-2014',
		date2: 'Thu 14:00, 05-May-2014'
	}, {
		title: 'Animations with canvas & SVG',
		date1: 'Wed 18:00, 04-May-2014',
		date2: 'Thu 14:00, 05-May-2014'
	}, {
		title: 'DOM operation',
		date1: 'Thu 18:00, 05-May-2014',
		date2: 'Fri 14:00, 06-May-2014'
	}, {
		title: 'Event Model',
		date1: 'Thu 18:00, 05-May-2014',
		date2: 'Fri 14:00, 06-May-2014'
	}];

	var source = $('#row-template').html(),
		template = Handlebars.compile(source),
		generatedHTML = template({
			lectures: lectures
		});

	$('table tbody').append(generatedHTML);

});