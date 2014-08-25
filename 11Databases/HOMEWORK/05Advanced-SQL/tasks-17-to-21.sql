-- task 17
CREATE TABLE Groups (
	GroupId INT PRIMARY KEY IDENTITY NOT NULL,
	Name nvarchar(50) UNIQUE NOT NULL
)

INSERT INTO Groups (Name)
VALUES
('Football'),
('Cricket'),
('Baseball')

-- task 18
ALTER TABLE Users
ADD GroupId INT NULL

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(GroupId)

INSERT INTO Users (UserName, Password, LastLogin, GroupId)
VALUES
('Ivan2', 'ivaninio321', GETDATE() - 10, 1),
('Mariya2', 'mariika421', GETDATE(), 2),
('Kalina2', 'kalink22', GETDATE() - 20, 3)

-- task 20
UPDATE Users
SET UserName = 'Kalinka22'
WHERE Username = 'Kalina2'

UPDATE Users
SET Password = NULL
WHERE LastLogin > GETDATE() - 5

UPDATE Groups
SET Name = 'American Football'
WHERE Name = 'Football'

-- task 21
DELETE FROM Users
WHERE UserName LIKE '%2%'