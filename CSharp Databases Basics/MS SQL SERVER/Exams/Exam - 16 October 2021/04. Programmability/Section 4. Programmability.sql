   USE CigarShop

GO

-- 11.Client with Cigars

CREATE FUNCTION dbo.udf_ClientWithCigars(@FirstName NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	    SET @Result =
	      (
	 SELECT COUNT(c.Id)
       FROM Clients AS c
  LEFT JOIN ClientsCigars AS cc
   	     ON c.Id = cc.ClientId
  LEFT JOIN Cigars AS ci
         ON cc.CigarId = ci.Id
      WHERE c.FirstName = @FirstName AND ci.CigarName IS NOT NULL
		  )
		 IF @Result IS NULL
	  BEGIN
	    SET @Result = 0 
	    END
     RETURN @Result
END

GO

SELECT dbo.udf_ClientWithCigars('Betty')

GO

-- 12.Search for Cigar with Specific Taste

CREATE PROC usp_SearchByTaste @taste VARCHAR(20)
AS
BEGIN
    SELECT c.CigarName
	     , CONCAT('$', c.PriceForSingleCigar) AS Price
		 , t.TasteType
		 , b.BrandName
		 , CONCAT(s.[Length], ' cm') AS CigarLength
		 , CONCAT(s.RingRange, ' cm') AS CigarRingRange
	  FROM Cigars AS c
	  JOIN Tastes AS t
	    ON c.TastId = t.Id
	  JOIN Brands AS b
	    ON c.BrandId = b.Id
      JOIN Sizes AS s
	    ON c.SizeId = s.Id
	 WHERE t.TasteType = @taste
  ORDER BY CigarLength, CigarRingRange DESC
END

GO

EXEC usp_SearchByTaste 'Woody'