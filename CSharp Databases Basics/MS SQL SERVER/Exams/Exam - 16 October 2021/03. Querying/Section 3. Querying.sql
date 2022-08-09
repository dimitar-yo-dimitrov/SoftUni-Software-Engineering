      USE CigarShop
 
-- 05.Cigars by Price
 
   SELECT CigarName
        , PriceForSingleCigar
        , ImageURL
     FROM Cigars
 ORDER BY PriceForSingleCigar, CigarName DESC
 
-- 06.Cigars by Taste
 
   SELECT c.Id
        , c.CigarName
        , c.PriceForSingleCigar
        , t.TasteType
        , t.TasteStrength
     FROM Cigars AS c
 	 JOIN Tastes AS t
 	   ON c.TastId = t.Id
    WHERE t.TasteType IN('Earthy', 'Woody')
 ORDER BY c.PriceForSingleCigar DESC
 
-- 07.Clients without Cigars

   SELECT c.Id
        , CONCAT(c.FirstName, ' ', c.LastName) AS ClientName
        , c.Email
     FROM Clients AS c
LEFT JOIN ClientsCigars AS cc
	   ON c.Id = cc.ClientId
LEFT JOIN Cigars AS ci
       ON cc.CigarId = ci.Id
    WHERE ci.CigarName IS NULL
 ORDER BY ClientName 

 -- 08.First 5 Cigars

   SELECT
   TOP(5) ci.CigarName
        , ci.PriceForSingleCigar
        , ci.ImageURL
     FROM Cigars AS ci
	 JOIN Sizes AS s
	   ON ci.SizeId = s.Id
	WHERE s.[Length] >= 12 
	      AND (ci.CigarName LIKE '%ci%' OR ci.PriceForSingleCigar > 50) 
		  AND s.RingRange > 2.55
 ORDER BY ci.CigarName, ci.PriceForSingleCigar DESC

 -- 09.Clients with ZIP Codes

   SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName
        , a.Country
        , a.ZIP
		, CONCAT('$',MAX(ci.PriceForSingleCigar)) AS CigarPrice
     FROM Addresses AS a
	 JOIN Clients AS c
	   ON c.AddressId = a.Id
     JOIN ClientsCigars AS cc
	   ON c.Id = cc.ClientId
	 JOIN Cigars AS ci
       ON cc.CigarId = ci.Id
	WHERE ISNUMERIC(a.ZIP) = 1
 GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
 ORDER BY FullName

 -- 10.Cigars by Size
   SELECT *
     FROM
	    (
		   SELECT c.LastName
				, AVG(s.[Length]) AS CiagrLength
				, CEILING(AVG(s.RingRange)) AS CiagrRingRange
			 FROM Clients AS c
			 JOIN ClientsCigars AS cc
			   ON c.Id = cc.ClientId
			 JOIN Cigars AS ci
			   ON cc.CigarId = ci.Id 
			 JOIN Sizes AS s
			   ON s.Id = ci.SizeId
		 GROUP BY c.LastName
				) AS sub
 ORDER BY sub.CiagrLength DESC
