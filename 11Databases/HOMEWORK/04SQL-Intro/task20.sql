SELECT e.FirstName + ' ' + e.LastName AS [EMPLOYEE NAME],
	e.ManagerID, m.EmployeeID,
	m.FirstName + ' ' + m.LastName AS [MANAGER NAME]
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID