        USE Bank

-- 9.Find Full Name

GO

CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
BEGIN
     SELECT 
	 CONCAT (FirstName
	      , ' '
		  , LastName) AS [Full Name]
	   FROM AccountHolders
END

GO

EXEC dbo.usp_GetHoldersFullName

-- 10.People with Balance Higher Than

GO

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan @number DECIMAL(18 ,4) 
AS
BEGIN
     SELECT ah.FirstName
	      , ah.LastName
	   FROM AccountHolders AS ah
	   JOIN Accounts AS a
	     ON ah.Id = a.AccountHolderId
   GROUP BY ah.FirstName
          , ah.LastName 
     HAVING SUM(a.Balance) > @number
   ORDER BY ah.FirstName
	      , ah.LastName
END

GO

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 48100

-- 11.Future Value Function

GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
	(@initialSum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18, 4)

	SET @futureValue = @initialSum * (POWER((1 + @yearlyInterestRate), @years))

	RETURN CAST(ROUND(@futureValue, 4) AS DECIMAL(18, 4))
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- 12.Calculating Interest

GO

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount  @accountId INT, @yearlyInterestRate FLOAT 
AS
BEGIN
     SELECT a.Id AS [Account Id]
	      , ah.FirstName
	      , ah.LastName
		  , a.Balance
		  , dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) AS [Balance in 5 years]
	   FROM AccountHolders AS ah
	   JOIN Accounts AS a
	     ON ah.Id = a.AccountHolderId
		 WHERE a.Id = @accountId
END

GO

EXEC dbo.usp_CalculateFutureValueForAccount '1', 0.1
