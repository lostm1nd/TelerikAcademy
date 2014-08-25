-- task1
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees)

-- task 2
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary >=
	(SELECT MIN(Salary) FROM Employees)
	AND Salary <=
	(SELECT MIN(Salary) FROM Employees) * 1.1
ORDER BY Salary

-- task 3
SELECT e.FirstName + ' ' + e.LastName AS [FULL NAME],
	e.Salary, d.Name
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees
	WHERE DepartmentID = e.DepartmentID)

-- task 4
SELECT ROUND(AVG(Salary), 0) AS [Average salary for dep 1]
FROM Employees
WHERE DepartmentID = 1

-- task 5
SELECT ROUND(AVG(e.Salary), 0) AS [Average salary for Sales]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'