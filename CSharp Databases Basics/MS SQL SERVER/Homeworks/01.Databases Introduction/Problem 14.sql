-- Problem 14.Car Rental Database

  	CREATE
  DATABASE CarRental  

       USE CarRental  

    CREATE
	 TABLE Categories  
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , CategoryName NVARCHAR(50) NOT NULL
		 , DailyRate INT
		 , WeeklyRate INT
		 , MonthlyRate INT
		 , WeekendRate INT
		 )

    INSERT 
      INTO Categories(CategoryName, DailyRate)
    VALUES
    	   ('A', 5)
    	 , ('B', 10)
    	 , ('C', 15)

	CREATE
	 TABLE Cars  
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , PlateNumber NVARCHAR(15) NOT NULL
		 , Manufacturer NVARCHAR(50) NOT NULL
		 , Model NVARCHAR(50) NOT NULL
		 , CarYear INT
		 , CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
		 , Doors INT
		 , Picture VARBINARY(MAX)
    	 , CHECK 
    	   (DATALENGTH([Picture]) <= 2000000)
		 , Condition INT
		 , Available BIT NOT NULL
		 )

    INSERT 
      INTO Cars(PlateNumber, Manufacturer, Model, CategoryId, Available)
    VALUES
    	   ('A123', 'Honda', 'Accord', 3, 0)
    	 , ('B111', 'Honda', 'CRV', 2, 1)
    	 , ('C333', 'Honda', 'Civic', 1, 1)

	CREATE
	 TABLE Employees   
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , FirstName NVARCHAR(50) NOT NULL
		 , LastName NVARCHAR(50) NOT NULL
		 , Title NVARCHAR(50) NOT NULL
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO Employees(FirstName, LastName, Title)
    VALUES
    	   ('Pesho', 'Petrov', 'Ninga')
    	 , ('Ivan', 'Ivanov', 'Comando')
    	 , ('Dimitar', 'Dimitrov', 'Superman')

	CREATE
	 TABLE Customers    
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , DriverLicenceNumber INT NOT NULL
		 , FullName NVARCHAR(100) NOT NULL
		 , [Address] NVARCHAR(70)
		 , City NVARCHAR(70) NOT NULL
		 , ZIPCode INT
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO Customers(DriverLicenceNumber, FullName, City)
    VALUES
    	   (125445, 'Petrov Petrov', 'Varna')
    	 , (166565, 'Ivanov Ivanov', 'Sofia')
    	 , (346465, 'Dimitrov Dimitrov', 'Plovdiv')

	CREATE
	 TABLE RentalOrders     
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
		 , CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL
		 , CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL
		 , TankLevel INT
		 , KilometrageStart INT
		 , KilometrageEnd INT
		 , TotalKilometrage INT
		 , StartDate DATE
		 , EndDate DATE
		 , TotalDays INT
		 , RateApplied INT
		 , TaxRate INT
		 , OrderStatus BIT NOT NULL
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO RentalOrders
	       (EmployeeId, CustomerId, CarId, OrderStatus)
    VALUES
    	   (1, 3, 2, 0)
    	 , (2, 3, 1, 1)
    	 , (3, 1, 3, 1)
    
    SELECT * 
      FROM RentalOrders
