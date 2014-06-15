$(document).ready(function() {
	'use strict';

	var students = [{
		firstName: 'Ivan',
		lastName: 'Ivanov',
		score: 380
	}, {
		firstName: 'Todor',
		lastName: 'Todorov',
		score: 450
	}, {
		firstName: 'Mira',
		lastName: 'Mironova',
		score: 480
	}, {
		firstName: 'Kiril',
		lastName: 'Kirilov',
		score: 410
	}];

	$('#generate').on('click', onGenerateBtnClick);

	$('#add').on('click', onAddBtnClick);

	function onGenerateBtnClick() {

		var $table = $('<table></table>'),
			tableHeaderAsString = (['<tr>',
									'<th>', 'First Name', '</th>',
									'<th>', 'Last Name', '</th>',
									'<th>', 'Score', '</th>',
									'</tr>']).join('');

		$table.append(tableHeaderAsString);

		students.forEach(function(student){
			var $row = $('<tr></tr>'),
				rowAsString = (['<td>', student.firstName, '</td>',
								'<td>', student.lastName, '</td>',
								'<td>', student.score, '</td>']).join('');

			$row.append(rowAsString);

			$table.append(row);
		});

		$('#table-container').append($table);
	}

	function onAddBtnClick() {
		$('form').find('p').remove();

		var firstName = $('#fn').val(),
			lastName = $('#ln').val(),
			score = $('#score').val();

		if (firstName === '' || lastName === '' || score === '') {
			$('form').append('<p style="color:red">You must fill all the fields.</p>');
		} else {
			students.push({
				firstName: firstName,
				lastName: lastName,
				score: score
			});
		}
	}
});