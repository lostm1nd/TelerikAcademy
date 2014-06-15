$(document).ready(function() {

	var books = [{
		id: 'js-good-parts',
		title: 'JS: The Good Parts'
	}, {
		id: 'js-ninja-secrets',
		title: 'Secrets of the JavaScript Ninja'
	}, {
		id: 'html5-canvas',
		title: 'Core HTML5 Canvas'
	}, {
		id: 'js-patterns',
		title: 'JS Patterns'
	}];

	var students = [{
		number: 1,
		name: 'Peter Petrov',
		mark: 5.5
	}, {
		number: 2,
		name: 'Ivan Petrov',
		mark: 4.55
	}, {
		number: 3,
		name: 'Maria Petrova',
		mark: 6
	}, {
		number: 4,
		name: 'Ivanka Petrova',
		mark: 5
	}];

	$('#books-list').listview(books);

	$('#students-table').listview(students);

});