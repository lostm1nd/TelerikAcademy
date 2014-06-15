$(document).ready(function() {
	var options = [{
		id: 1,
		text: 'Item #1'
	}, {
		id: 2,
		text: 'Item #2'
	}, {
		id: 3,
		text: 'Item #3'
	}, {
		id: 4,
		text: 'Item #4'
	}, {
		id: 5,
		text: 'Item #5'
	}, {
		id: 6,
		text: 'Item #6'
	}];

	var source = $('#option-template').html(),
		template = Handlebars.compile(source),
		generatedHTML = template({
			options: options
		});

	$('select').append(generatedHTML);
});