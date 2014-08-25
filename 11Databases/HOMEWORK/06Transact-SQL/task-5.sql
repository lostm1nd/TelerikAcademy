CREATE PROC usp_WithdrawMoney(@accountId int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE AccountId = @accountId
	COMMIT
GO

CREATE PROC usp_DepositMoney(@accountId int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE AccountId = @accountId
	COMMIT
GO

EXEC usp_WithdrawMoney 1, 50
EXEC usp_DepositMoney 1, 150