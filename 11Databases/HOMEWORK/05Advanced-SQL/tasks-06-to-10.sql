-- task 6
SELECT COUNT(e.FirstName) AS [Employees in Sales]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- task 7
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL

-- task 8
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

-- task 9
SELECT ROUND(AVG(e.Salary), 0) AS [Avarage salary for department],
	d.Name
FROM Departments d
	INNER JOIN Employees e
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

-- task 10
SELECT COUNT(*) AS [Employee count],
	e.DepartmentID,
	d.DepartmentID,
	d.Name,
	t.Name
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY e.DepartmentID, d.DepartmentID, d.Name, t.Name
