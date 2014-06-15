$(document).ready(function(){
	'use strict';

	var slidesCount = $('#slider img').length;

	$('.slider-arrow').on('click', onSliderArrowClick);

	// setInterval(function() {
	// 	$('#right-arrow').trigger('click');
	// }, 5000);

	function onSliderArrowClick() {
		var arrowID = $(this).attr('id'),
			currentSlide = $('.shown').data('slide'),
			$imageToAnimate;

		if (arrowID === 'left-arrow') {
			// if we are currently at the first slide
			// we take the last slide
			var prevSlide = (currentSlide === 1) ? slidesCount : currentSlide - 1; 
			$imageToAnimate = $('[data-slide="' + prevSlide + '"]');

			$imageToAnimate.addClass('slide-in').css({'left': '601px'});
			$imageToAnimate.animate({'left': 0}, 'slow', swapVisibility);
		} else {
			// take the next slide or the first in the list
			// if we have reached the end of the list
			var nextSlide = (currentSlide === slidesCount) ? 1 : currentSlide + 1;
			$imageToAnimate = $('[data-slide="' + nextSlide + '"]');

			$imageToAnimate.addClass('slide-in').css({'left': '-601px'});
			$imageToAnimate.animate({'left': 0}, 'slow', swapVisibility);
		}

		// swap the classes - first remove the previous shown image
		// the add the class to the current image
		// and last remove the slide-in class
		// so the next image to slide in can use the z-index
		// we want that to happen after the animation has
		// finish so we attach it as a callback
		function swapVisibility() {
			$('[data-slide="' + currentSlide + '"]').removeClass('shown');
			$imageToAnimate.addClass('shown').removeClass('slide-in');
		}	
	}
});