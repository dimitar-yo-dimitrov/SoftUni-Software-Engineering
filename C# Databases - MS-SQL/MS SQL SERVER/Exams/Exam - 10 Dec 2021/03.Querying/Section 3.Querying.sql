     USE Airport

-- 05.Aircraft

   SELECT a.Manufacturer
        , a.Model
		, a.FlightHours
		, a.Condition
     FROM Aircraft AS a
 ORDER BY a.FlightHours DESC

 -- 06.Pilots and Aircraft

   SELECT p.FirstName
        , p.LastName
		, a.Manufacturer
		, a.Model
		, a.FlightHours
     FROM Pilots AS p
	 JOIN PilotsAircraft AS pa
	   ON p.Id = pa.PilotId
	 JOIN Aircraft AS a
	   ON pa.AircraftId = a.Id
    WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
 ORDER BY a.FlightHours DESC, p.FirstName

 -- 07.Top 20 Flight Destinations

   SELECT
  TOP(20) fd.Id AS DestinationId
        , fd.[Start]
        , p.FullName
        , a.AirportName
		, fd.TicketPrice
     FROM FlightDestinations AS fd
	 JOIN Passengers AS p
	   ON p.Id = fd.PassengerId
     JOIN Airports AS a
	   ON fd.AirportId = a.Id
    WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
 ORDER BY fd.TicketPrice DESC, a.AirportName

 -- 08.Number of Flights for Each Aircraft

   SELECT a.Id AS AircraftId
        , a.Manufacturer
		, a.FlightHours
		, COUNT(fd.AircraftId) AS FlightDestinationsCount
		, ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
     FROM Aircraft AS a
	 JOIN FlightDestinations AS fd
	   ON a.Id = fd.AircraftId
 GROUP BY a.Id, a.Manufacturer, a.FlightHours
   HAVING COUNT(fd.AircraftId) >= 2
 ORDER BY FlightDestinationsCount DESC, AircraftId

 -- 09.Regular Passengers

   SELECT p.FullName
        , COUNT(fd.AircraftId) AS CountOfAircraft
		, SUM(fd.TicketPrice) AS TotalPayed
     FROM Passengers AS p
	 JOIN FlightDestinations AS fd
	   ON p.Id = fd.PassengerId
     JOIN Aircraft AS a
	   ON a.Id = fd.PassengerId
 GROUP BY p.FullName, a.Id, a.Manufacturer, a.FlightHours
   HAVING COUNT(fd.AircraftId) > 1 AND SUBSTRING(p.FullName, 2, 1) = 'a'
 ORDER BY p.FullName

 -- 10.Full Info for Flight Destinations

   SELECT a.AirportName 
        , fd.[Start] AS DayTime
        , fd.TicketPrice
		, p.FullName
		, acr.Manufacturer
		, acr.Model
     FROM Airports AS a
	 JOIN FlightDestinations AS fd
	   ON a.Id = fd.AirportId
     JOIN Passengers AS p
	   ON fd.PassengerId = p.Id
     JOIN Aircraft AS acr
	   ON fd.AircraftId = acr.Id
    WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20 AND fd.TicketPrice > 2500 
 ORDER BY acr.Model




