       USE Airport
  
  -- 02.Insert
    INSERT 
      INTO Passengers(FullName, Email)
   (SELECT CONCAT(p.FirstName, ' ', p.LastName) AS FullName  
   	     , CONCAT(p.FirstName, p.LastName, '@gmail.com') AS Email 
      FROM Pilots AS p
     WHERE p.Id BETWEEN 5 AND 15)
  
  -- 03.Update
  
    UPDATE Aircraft
       SET Condition = 'A'
     WHERE Condition IN ('C', 'B') 
                     AND (FlightHours IS NULL OR FlightHours <= 100) 
  
-- 04.Delete
     ALTER
     TABLE FlightDestinations
      DROP
CONSTRAINT DF__FlightDes__Ticke__3E52440B

    DELETE
      FROM Passengers
     WHERE LEN(FullName) >= 10

    SELECT COUNT(*) FROM Passengers




