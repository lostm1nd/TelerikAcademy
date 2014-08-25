SELECT FirstName, LastName, HireDate
FROM Employees
WHERE '1/1/1995' <= HireDate AND HireDate < '1/1/2005'