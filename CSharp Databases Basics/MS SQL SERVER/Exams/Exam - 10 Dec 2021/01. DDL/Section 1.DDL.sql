  CREATE DATABASE Airport

      GO

     USE Airport

	  GO

-- Section 1.DDL 

  CREATE 
   TABLE Passengers(
         Id INT PRIMARY KEY IDENTITY 
  	   , FullName VARCHAR(100) UNIQUE NOT NULL
  	   , Email VARCHAR(50) UNIQUE NOT NULL) 
  
  CREATE 
   TABLE Pilots(
         Id INT PRIMARY KEY IDENTITY
  	   , FirstName VARCHAR(30) UNIQUE NOT NULL
  	   , LastName VARCHAR(30) UNIQUE NOT NULL
  	   , Age TINYINT NOT NULL
	   , CHECK(Age BETWEEN 21 AND 62) 
  	   , Rating FLOAT
	   , CHECK(Rating BETWEEN 0.0 AND 10.0)) 

  CREATE 
   TABLE AircraftTypes(
         Id INT PRIMARY KEY IDENTITY
  	   , TypeName VARCHAR(30) UNIQUE NOT NULL) 

  CREATE 
   TABLE Aircraft(
         Id INT PRIMARY KEY IDENTITY(1,1)
  	   , Manufacturer VARCHAR(25) NOT NULL
  	   , Model VARCHAR(30) NOT NULL
  	   , [Year] INT NOT NULL
  	   , FlightHours INT
  	   , Condition CHAR(1) NOT NULL
  	   , TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL) 

  CREATE 
   TABLE PilotsAircraft(
         AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id)
  	   , PilotId INT FOREIGN KEY REFERENCES Pilots(Id)
	   , PRIMARY KEY(AircraftId, PilotId))

  CREATE 
   TABLE Airports(
         Id INT PRIMARY KEY IDENTITY
  	   , AirportName VARCHAR(70) UNIQUE NOT NULL
	   , Country VARCHAR(100) UNIQUE NOT NULL)

  CREATE 
   TABLE FlightDestinations(
         Id INT PRIMARY KEY IDENTITY
  	   , AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL
  	   , [Start] DATETIME NOT NULL
  	   , AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL
  	   , PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
  	   , TicketPrice DECIMAL(18,2) DEFAULT(15) NOT NULL) 

	  GO 
