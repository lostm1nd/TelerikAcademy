$.fn.tabs = function () {
	var selector = this;

	selector.addClass('tabs-container');
	selector.find('.tab-item').first().addClass('current');
	selector.find('.tab-item-content').css('display', 'none');
	selector.find('.current').find('.tab-item-content').css('display', '');

	$(document).on('click', '.tab-item', function() {
		$('.current').find('.tab-item-content').css('display', 'none');
		$('.current').removeClass('current');

		$(this).addClass('current');
		$(this).find('.tab-item-content').css('display', '');
	});

	return this;
};