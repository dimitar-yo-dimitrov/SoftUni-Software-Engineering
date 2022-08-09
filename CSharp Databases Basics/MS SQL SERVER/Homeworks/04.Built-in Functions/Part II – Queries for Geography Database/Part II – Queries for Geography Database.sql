    USE [Geography] 

-- Problem 12.	Countries Holding ‘A’ 3 or More Times 

   SELECT CountryName
        , IsoCode
     FROM Countries
	WHERE UPPER(CountryName) LIKE '%A%A%A%'
	ORDER BY IsoCode

-- Problem 13.Mix of Peak and River Names

   SELECT p.PeakName
        , r.RiverName
		, LOWER(CONCAT(LEFT (p.PeakName, LEN(p.PeakName) - 1), r.RiverName))
       AS Mix
     FROM Rivers AS r
	    , Peaks AS p
    WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
	ORDER BY Mix