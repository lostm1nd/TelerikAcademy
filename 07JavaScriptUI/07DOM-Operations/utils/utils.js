function getRandomRgbColor() {
	var red = getRandomInt(0, 255),
		green = getRandomInt(0, 255),
		blue = getRandomInt(0, 255);

	return 'rgb(' + red + ',' + green + ',' + blue + ')';
}

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

function getDocHeight() {
    var doc = document;
    return Math.max(
        doc.body.scrollHeight, doc.documentElement.scrollHeight,
        doc.body.offsetHeight, doc.documentElement.offsetHeight,
        doc.body.clientHeight, doc.documentElement.clientHeight
    );
}

function getDocWidth() {
    var doc = document;
    return Math.max(
        doc.body.scrollWidth, doc.documentElement.scrollWidth,
        doc.body.offsetWidth, doc.documentElement.offsetWidth,
        doc.body.clientWidth, doc.documentElement.clientWidth
    );
}