SELECT e.FirstName, e.LastName, e.JobTitle, e.DepartmentID, d.DepartmentID,
	e.AddressID, a.AddressID, a.AddressText, a.TownID, t.TownID, t.Name
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON a.TownID = t.TownID
WHERE e.JobTitle = 'Sales Representative'
	