window.onload = function() {
	var addBtn = document.getElementById('add'),
		list = document.getElementById('todo-list'),
		input = document.getElementById('todo'),
		showBtn = document.getElementById('show'),
		hideBtn = document.getElementById('hide');

	addBtn.addEventListener('click', function() {
		if (input.value !== '') {
			var li = document.createElement('li');
			li.innerHTML = input.value;
			list.appendChild(li);
		}
	}, false);

	showBtn.addEventListener('click', function() {
		list.style.display = '';
	}, false);

	hideBtn.addEventListener('click', function() {
		list.style.display = 'none';
	}, false);

	list.addEventListener('click', function(ev) {
		ev = event || window.event;

		list.removeChild(ev.target);
	}, false);
};