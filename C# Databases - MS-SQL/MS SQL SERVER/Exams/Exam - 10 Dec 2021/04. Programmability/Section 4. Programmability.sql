        USE Airport

GO

-- 11.Find all Destinations by Email Address

CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
 RETURNS INT
 AS
 BEGIN
	DECLARE @Result INT
	    SET @Result =
	      (
	 SELECT COUNT(fd.PassengerId)
	   FROM Passengers AS p
	   JOIN FlightDestinations AS fd
	     ON p.Id = fd.PassengerId
      WHERE p.Email = @email
   GROUP BY p.Email
          )
		 IF @Result IS NULL
	  BEGIN
	        SET @Result = 0 
	    END
     RETURN @Result
END

GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')

GO

-- 12.Full Info for Airports

CREATE OR ALTER PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
    SELECT AirportName
         , FullName
         , CASE WHEN fd.TicketPrice <= 400 THEN 'Low'
		        WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		        WHEN fd.TicketPrice > 1501 THEN 'High'
	          END AS LevelOfTickerPrice
         , Manufacturer
         , Condition
         , TypeName
      FROM Airports AS a
	  JOIN FlightDestinations AS fd
	    ON a.Id = fd.AirportId 
      JOIN Passengers AS p
	    ON fd.PassengerId = p.Id
	  JOIN Aircraft AS aa
	    ON fd.AircraftId = aa.Id
	  JOIN AircraftTypes AS aat
	    ON aa.TypeId = aat.Id
	 WHERE AirportName = @airportName
  ORDER BY Manufacturer, FullName 
END

GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'