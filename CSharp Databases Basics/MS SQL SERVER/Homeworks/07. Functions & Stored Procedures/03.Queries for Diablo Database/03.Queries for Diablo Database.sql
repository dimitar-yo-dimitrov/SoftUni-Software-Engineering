          USE Diablo

-- 13.*Scalar Function: Cash in User Games Odd Rows

GO

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50)) 
RETURNS TABLE
AS
RETURN 
	   SELECT SUM(Cash) AS SumCash 
         FROM
			  (SELECT g.Id 
					, g.[Name] 
					, ug.Cash
					, ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
				 FROM UsersGames AS ug
				 JOIN Games AS g
				   ON g.Id = ug.GameId
				WHERE g.[Name] = @gameName) AS SubQuery
		WHERE RowNumber % 2 <> 0
GO

       SELECT * 
         FROM dbo.ufn_CashInUsersGames('Love in a mist')
