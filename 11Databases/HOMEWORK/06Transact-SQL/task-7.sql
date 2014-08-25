CREATE FUNCTION ufn_ConsistsOfGivenCharacters(@word nvarchar, @chars nvarchar)
	RETURNS BIT
AS
	BEGIN
		SET @word = LOWER(@word)
		SET @chars = LOWER(@chars)
		DECLARE @len int = LEN(@word)
		DECLARE @index int = 1

		WHILE (@index <= @len)
		BEGIN
			IF (CHARINDEX(SUBSTRING(@word, @index, 1), @chars) = 0 OR
				@word IS NULL)
			BEGIN
				RETURN 0
			END

			SET @index = @index + 1
		END

		RETURN 1
	END
GO

CREATE FUNCTION ufn_FindPersonOrTownByChars(@chars nvarchar)
	RETURNS TABLE
AS
	RETURN (
		SELECT FirstName
		FROM Employees
		WHERE 1 = (SELECT dbo.ufn_ConsistsOfGivenCharacters(FirstName, @chars))
			UNION
		SELECT MiddleName
		FROM Employees
		WHERE 1 = (SELECT dbo.ufn_ConsistsOfGivenCharacters(MiddleName, @chars))
			UNION
		SELECT LastName
		FROM Employees
		WHERE 1 = (SELECT dbo.ufn_ConsistsOfGivenCharacters(LastName, @chars))
			UNION
		SELECT Name
		FROM Towns
		WHERE 1 = (SELECT dbo.ufn_ConsistsOfGivenCharacters(Name, @chars))
	)
GO

SELECT * FROM dbo.ufn_FindPersonOrTownByChars('oistmiahf')