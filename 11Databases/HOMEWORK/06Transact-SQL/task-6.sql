ALTER TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT d.AccountId, d.Balance, i.Balance
	FROM deleted d, inserted i
GO

EXEC usp_DepositMoney 1, 200

EXEC usp_WithdrawMoney 1, 150