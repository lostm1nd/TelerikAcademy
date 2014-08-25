SELECT e.FirstName + ' ' + e.LastName AS [EMPLOYEE NAME],
	e.ManagerID, m.EmployeeID,
	m.FirstName + ' ' + m.LastName AS [MANAGER NAME],
	m.AddressID, a.AddressID,
	a.AddressText AS [MANAGER ADDRESS]
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
		ON m.AddressID = a.AddressID