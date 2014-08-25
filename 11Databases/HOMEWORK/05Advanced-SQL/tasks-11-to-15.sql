-- task 11
SELECT m.FirstName, m.LastName
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5

-- task 12
SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'No employee') AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Manager]
FROM Employees e
	FULL OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

-- task 13
SELECT FirstName, LastName, Salary
FROM Employees
GROUP BY FirstName, LastName, Salary
HAVING LEN(LastName) = 5

-- task 14
SELECT CONVERT(VARCHAR(24), GETDATE(), 113)

-- task 15
CREATE TABLE Users(
	UserId int PRIMARY KEY IDENTITY NOT NULL,
	Username nvarchar(50) NOT NULL
		CONSTRAINT UC_Username UNIQUE(Username),
	Password nvarchar(50) NOT NULL
		CONSTRAINT CK_Password CHECK (LEN(Password) > 5),
	FullName nvarchar(100) NULL,
	LastLogin date NULL
)

INSERT INTO Users (Username, Password, LastLogin)
VALUES
('Pesho', 'peshoto123', GETDATE()),
('Todor', 'todorko321', GETDATE() - 2),
('Gosho', 'goshoto123', GETDATE()),
('Ivan', 'ivaninio321', GETDATE() - 10),
('Mariya', 'mariika421', GETDATE()),
('Kalina', 'kalink22', NULL)