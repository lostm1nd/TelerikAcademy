CREATE PROC usp_CalculateInterestForOneMonth(@accountId int, @interest float)
AS
	SELECT TransactSQL.dbo.ufn_CalculateInterest(Balance, @interest, 1)
	FROM Accounts
	WHERE AccountId = @accountId
GO

SELECT TransactSQL.dbo.ufn_CalculateInterest(5500, 5, 1)
EXEC usp_CalculateInterestForOneMonth 10, 5