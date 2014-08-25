CREATE PROC usp_PersonWithBalanceMoreThan(@balance as money)
AS
	SELECT *
		FROM Accounts a
			INNER JOIN People p
				ON a.PersonId = p.PersonId
	WHERE a.Balance > @balance
GO

EXEC usp_PersonWithBalanceMoreThan 1000