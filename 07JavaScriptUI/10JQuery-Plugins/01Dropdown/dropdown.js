(function($) {

$.fn.dropdown = function() {
	var $selectedElement = this;

	$selectedElement.css('display', 'none');

	var options = $selectedElement.find('option');

	var divContainer = $('<div></div>').addClass('dropdown-list-container');

	var listOptions = $('<ul></ul>').addClass('dropdown-list-options');

	options.each(function(index, option){
		var li = $('<li></li>').addClass('dropdown-list-option')
				.text($(option).text()).attr('data-value', $(option).val());

		listOptions.append(li);
	});

	divContainer.append(listOptions);

	divContainer.on('click', '.dropdown-list-option', function() {
		var $clickedLi = $(this);
		
		$selectedElement.find('[selected="selected"]').removeAttr('selected');

		$('.selected-li').removeClass('selected-li').css('background-color', '');

		$clickedLi.addClass('selected-li').css('background-color', 'purple');

		var selectedOption = $clickedLi.attr('data-value');
		
		$selectedElement.find('[value="' + selectedOption + '"]').attr('selected', 'selected');
	});

	$selectedElement.after(divContainer);

	return $selectedElement;
};

}(jQuery));