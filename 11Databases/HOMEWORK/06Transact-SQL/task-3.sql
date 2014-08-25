CREATE FUNCTION ufn_CalculateInterest(@balance money, @interest float, @months int)
	RETURNS money
AS
BEGIN
	RETURN @balance * ( (@interest / 100) * (@months / 12.0))
END
GO

SELECT dbo.ufn_CalculateInterest(4250.50, 5, 12) AS [Interest]