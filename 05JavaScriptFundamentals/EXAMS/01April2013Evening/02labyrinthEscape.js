function Solve(args) {
	var startPosition = args[1].split(' '),
		currRow = parseInt(startPosition[0], 10),
		currCol = parseInt(startPosition[1], 10),
		sumOfPath = 0,
		cellsInPath = 0,
		counter = 1,
		field = [],
		directions = [];

	// fill the numbers in the field array
	// and the directions in a separate array
	for (var row = 2; row < args.length; row+=1) {

		// subtract 2 to compensate for starting at
		// index 2 in the args array
		// we want field and directions to start at index 0
		field[row - 2] = [];
		directions[row - 2] = [];

		for (var col = 0; col < args[row].length; col+=1) {
			field[row-2].push(counter);
			directions[row-2].push(args[row][col]);
			counter += 1;
		}	
	}

	// execute commands
	while (true) {

		// if the row does not exist we are out
		// if the col does not exist we are out
		if (!field[currRow] || !field[currRow][currCol]) {
			// console.log('out ' + sumOfPath);
			return ('out ' + sumOfPath);

		// if the cell is already visited we are lost
		} else if (field[currRow][currCol] === 'visited') {
			// console.log('lost ' + cellsInPath);
			return ('lost ' + cellsInPath);

		// if the cell exist and it is not visited
		// we add its value to the sum and count +1 more step
		} else {
			sumOfPath += field[currRow][currCol];
			cellsInPath += 1;
			field[currRow][currCol] = 'visited';
		}

		if (directions[currRow][currCol] === 'l') {				
			currCol -= 1;
		} else if (directions[currRow][currCol] === 'r') {
			currCol += 1;
		} else if (directions[currRow][currCol] === 'u') {
			currRow -= 1;
		} else {
			currRow += 1;
		}
	}
}

Solve([
'2 31',
'1 24',
'ullllrrrlluurruluurrdduldddurdl',
'rululludrluuurrlrllllulduurllrd']);