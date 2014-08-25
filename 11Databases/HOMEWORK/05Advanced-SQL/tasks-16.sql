-- task 16
CREATE VIEW UsersLoggedInToday
AS
SELECT *
FROM Users
WHERE LastLogin = '25/8/2014'