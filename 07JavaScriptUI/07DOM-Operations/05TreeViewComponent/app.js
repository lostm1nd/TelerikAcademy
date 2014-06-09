window.onload = function() {
	var treeContainer = document.getElementById('tree-container');

	treeContainer.addEventListener('click', function(ev) {
		ev = event || window.event;

		var targetElement = ev.target,
			listElement = targetElement.nextSibling;

			while (listElement.nextSibling &&
					!(listElement instanceof HTMLUListElement)) {
				
				listElement = listElement.nextSibling;
			}

		if (listElement instanceof HTMLUListElement &&
				listElement.style.display === 'block') {

			listElement.style.display = '';

		} else if (listElement instanceof HTMLUListElement) {
			listElement.style.display = 'block';
		}

	}, false);
};