INSERT INTO Users(Username, Password, FullName, LastLogin)
SELECT TOP 20 
	SUBSTRING(e.FirstName,1,1) + LOWER(e.LastName),
	SUBSTRING(e.FirstName,1,1) + LOWER(e.LastName) + 'pass',
	e.FirstName + ' ' + e.LastName,
	NULL
FROM Employees e