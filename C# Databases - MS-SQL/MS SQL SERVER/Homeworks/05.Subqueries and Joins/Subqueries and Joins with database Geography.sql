      USE [Geography]

-- 12.Highest Peaks in Bulgaria

   SELECT c.CountryCode
        , m.MountainRange
        , p.PeakName
        , p.Elevation
     FROM Countries AS c
	 JOIN MountainsCountries AS mc
	   ON mc.CountryCode = c.CountryCode
	 JOIN Mountains AS m
	   ON mc.MountainId = m.Id
	 JOIN Peaks AS p
	   ON p.MountainId = m.Id
    WHERE c.CountryCode IN('BG') AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 -- 13.Count Mountain Ranges

   SELECT c.CountryCode
        , COUNT(m.MountainRange)
     FROM Countries AS c
	 JOIN MountainsCountries AS mc
	   ON mc.CountryCode = c.CountryCode
	 JOIN Mountains AS m
	   ON mc.MountainId = m.Id
    WHERE c.CountryCode IN('US', 'BG', 'RU')
 GROUP BY c.CountryCode

 -- 14.Countries with Rivers

   SELECT 
   TOP(5) c.CountryName
        , r.RiverName
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
	   ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r
	   ON cr.RiverId = r.Id
    WHERE c.ContinentCode IN('AF')
 ORDER BY c.CountryName

 -- 15.*Continents and Currencies
   
   SELECT ContinentCode
        , CurrencyCode
		, Total AS CurrencyUsage
     FROM
	    (
   SELECT co.ContinentCode
        , cu.CurrencyCode
		, COUNT(cu.CurrencyCode) AS Total
		, DENSE_RANK() OVER(PARTITION BY co.ContinentCode ORDER BY COUNT(cu.CurrencyCode) DESC) AS Ranked
	 FROM Continents AS co
LEFT JOIN Countries AS c
       ON co.ContinentCode = c.ContinentCode
LEFT JOIN Currencies AS cu
       ON cu.CurrencyCode = c.CurrencyCode
 GROUP BY co.ContinentCode, cu.CurrencyCode
        ) AS Subquery
    WHERE Ranked = 1 AND Total > 1
   
 -- 16.Countries without Any Mountains   

   SELECT COUNT(*) 
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	   ON mc.CountryCode = c.CountryCode
    WHERE mc.MountainId IS NULL

 -- 17.Highest Peak and Longest River by Country

   SELECT 
   TOP(5) c.CountryName
        , MAX(p.Elevation) AS HighestPeakElevation
        , MAX(r.[Length]) AS LongestRiverLength
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	   ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
	   ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p 
	   ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr
	   ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r
	   ON cr.RiverId = r.Id
 GROUP BY c.CountryName
 ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

 -- 18.Highest Peak Name and Elevation by Country

   SELECT 
   TOP(5) Country
        , ISNULL(PeakName, '(no highest peak)') As [Highest Peak Name]
        , CASE 
		       WHEN Elevation IS NULL THEN '0'
		       ELSE	Elevation
		  END AS [Highest Peak Elevation]
		, ISNULL(MountainRange, '(no mountain)') AS Mountain
     FROM
	    (
   SELECT c.CountryName AS Country
        , m.MountainRange
        , p.PeakName
        , p.Elevation
		, DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC)
	   AS PeakRank
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	   ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
	   ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p 
	   ON p.MountainId = m.Id
	    ) AS PeakRankingQuery
    WHERE PeakRank = 1
 ORDER BY Country, [Highest Peak Name]