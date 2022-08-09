-- Problem 15.Hotel Database

    CREATE
  DATABASE Hotel

       USE Hotel

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
		   AccountNumber INT PRIMARY KEY IDENTITY NOT NULL
		 , FirstName NVARCHAR(50) NOT NULL
		 , LastName NVARCHAR(50) NOT NULL
		 , PhoneNumber INT 
		 , EmergencyName NVARCHAR(50)
		 , EmergencyNumber INT
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO Customers(FirstName, LastName)
    VALUES
    	   ('Peter', 'Petrov')
    	 , ('Ivan', 'Ivanov')
    	 , ('Dimitar', 'Dimitrov')

	CREATE
	 TABLE RoomStatus     
	     (
		   RoomStatus NCHAR(1) PRIMARY KEY NOT NULL
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO RoomStatus(RoomStatus)
    VALUES
    	   ('A')
    	 , ('B')
    	 , ('C')

	CREATE
	 TABLE RoomTypes     
	     (
		   RoomType VARCHAR(10) PRIMARY KEY NOT NULL
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO RoomTypes(RoomType)
    VALUES
    	   ('Single')
    	 , ('Double')
    	 , ('Family')

	CREATE
	 TABLE BedTypes     
	     (
		   BedType VARCHAR(15) PRIMARY KEY NOT NULL
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO BedTypes(BedType)
    VALUES
    	   ('Small')
    	 , ('Large')
    	 , ('Extra Large')

	CREATE
	 TABLE Rooms   
	     (
		   RoomNumber INT PRIMARY KEY IDENTITY NOT NULL
		 , RoomType VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL
		 , BedType VARCHAR(15) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL
		 , Rate INT NOT NULL
		 , RoomStatus NCHAR(1) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL
		 , Notes NVARCHAR(500)
		 )

    INSERT 
      INTO Rooms (RoomType, BedType, Rate, RoomStatus)
    VALUES
    	   ('Single', 'Small', 40, 'A')
    	 , ('Double', 'Large', 70, 'B')
    	 , ('Family', 'Extra Large', 100, 'C')

    CREATE
	 TABLE Payments      
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
		 , PaymentDate DATE NOT NULL
		 , AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
		 , FirstDateOccupied DATE
		 , LastDateOccupied DATE
		 , TotalDays INT NOT NULL
		 , AmountCharged DECIMAL(7, 2) NOT NULL
		 , TaxRate DECIMAL(4, 2)
		 , TaxAmount DECIMAL(7, 2) NOT NULL
		 , PaymentTotal DECIMAL(7, 2) NOT NULL
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Payments
	       (EmployeeId, PaymentDate, AccountNumber, TotalDays, AmountCharged, TaxAmount, PaymentTotal)
    VALUES
    	   (1, '03.15.2021', 1, 3, 120, 50, 170)
    	 , (2, '05.25.2022', 2, 3, 210, 50, 260)
    	 , (3, '07.05.2022', 3, 3, 300, 50, 350)

	CREATE
	 TABLE Occupancies       
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
		 , DateOccupied DATE NOT NULL
		 , AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
		 , RoomNumber INT NOT NULL
		 , RateApplied DECIMAL(2, 1) NOT NULL
		 , PhoneCharge BIT
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Occupancies
	       (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
    VALUES
    	   (1, '03.15.2021', 1, 1, 7.7)
    	 , (2, '05.25.2022', 2, 3, 8.1)
    	 , (3, '07.05.2022', 3, 2, 9.3)
    
    SELECT * 
      FROM Occupancies