INSERT INTO Users (Username, LastLogin)
VALUES
('aaaaa', GETDATE() - 5000),
('bbbbb', GETDATE() - 5400),
('ccccc', GETDATE() - 5200),
('ddddd', GETDATE() - 5300)

UPDATE Users
SET Password = NULL
WHERE LastLogin < '10/03/2010'