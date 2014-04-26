Pillars
You are given a list of 8 bytes (positive integers in the range [0…255]) n0, n1, …, n7. These numbers represent a square grid consisting of 8 lines and 8 columns. Each cell of the grid could either be empty or full. The first line is represented by the bits of n0, the second – by the bits of n1 and so on, and the last line is represented by the bits of n7. Each bit with value 1 denotes a full cell and each bit with value 0 denotes an empty cell. The lines are numbered from the first (top) to the last (bottom) with the numbers 0, 1, …, 7. The columns are numbered from right to left with the indices 0, 1, …, 7. The figure shows a square grid and its representation by a sequence of 8 numbers n0, n1, …, n7:
	7	6	5	4	3	2	1	0	
0									n0 = 0
1		■							n1 = 64
2									n2 = 0
3					■				n3 = 8
4									n4 = 0
5					■	■			n5 = 12
6	■	■	■						n6 = 224
7									n7 = 0
We are allowed to put a vertical pillar over any of the columns in the grid. Pillars split the grid into two sides (left and right) and the column holding the pillar is ignored. Write a program that finds the leftmost column where the pillar can be put so that the full cells on the left side and on the right side are equal number. For example at the figure if we put the pillar at column 5, it will split the grid into two sides and both sides will have exactly 3 full cells.
Input
The input data should be read from the console.
There will be exactly 8 lines each holding the integer numbers n0, n1, …, n7.
The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output data should be printed on the console.
If a pillar splitting the grid into two vertical sides each holding the same number of full cells exists, print its column index on the first line and the number of full cells in each of the sides. If multiple pillars can do the job, print only the leftmost. If no such pillar exists, print the string "No" on the console (just one line holding the word "No").
Constraints
•	The numbers n0, n1, …, n7 are positive integers in the range [0…255].
•	Allowed work time for your program: 0.25 seconds.
•	Allowed memory: 16 MB.
