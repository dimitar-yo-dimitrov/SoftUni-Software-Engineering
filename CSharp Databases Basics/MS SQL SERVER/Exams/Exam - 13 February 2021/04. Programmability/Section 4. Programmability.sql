   USE Bitbucket

-- 11.All User Commits

GO

CREATE OR ALTER FUNCTION  udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	    SET @result = 
				  (
					SELECT COUNT(c.ContributorId)
					  FROM Users AS u
					  JOIN Commits AS c
						ON u.Id = c.ContributorId
					 WHERE u.Username = @username
				  GROUP BY c.ContributorId
				  )
	     IF @result IS NULL
	  BEGIN
	    SET @result = 0 
	    END
    RETURN @result
END

GO

SELECT dbo.udf_AllUserCommits('Under')

GO

-- 12. Search for Files

CREATE OR ALTER PROC usp_SearchForFiles @fileExtension VARCHAR(10)
AS
BEGIN
   SELECT DISTINCT pk.Id
                 , (pk.[Name])
                 , CONCAT(pk.Size, 'KB') AS Size
              FROM Files AS pk
		 LEFT JOIN Files AS fk
			    ON pk.Id = fk.ParentId
		     WHERE pk.[Name] LIKE CONCAT('%', @fileExtension, '%')
		  ORDER BY Id, [Name], Size DESC
END

GO

EXEC usp_SearchForFiles 'json'

