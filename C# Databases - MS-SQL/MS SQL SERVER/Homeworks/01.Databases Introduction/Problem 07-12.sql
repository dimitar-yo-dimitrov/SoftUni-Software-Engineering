--  Problem 07. Create Table People

       USE Minions
    CREATE 
     TABLE People
         (
    	   Id INT PRIMARY KEY IDENTITY NOT NULL
    	 , [Name] NVARCHAR(200) NOT NULL
    	 , Picture VARBINARY(MAX)
    	 , CHECK 
    	   (DATALENGTH([Picture]) <= 2000000)
    	 , Height DECIMAL(3,2)
    	 , [Weight] DECIMAL(5,2)
    	 , Gender CHAR(1) NOT NULL
    	 , CHECK 
    	   ([Gender] = 'm' OR [Gender] = 'f')
    	 , Birthdate DATE NOT NULL,
    	   Biography NVARCHAR(MAX)
         )
    
    INSERT 
      INTO People([Name], Height, [Weight], Gender, Birthdate)
    VALUES
    	   ('Dimitar', 1.81, 72.3, 'm', '1999-03-23')
    	 , ('Doncho', 1.71, 68.2, 'm', '1995-01-20')
    	 , ('Darina', 1.65, 55.5, 'f', '1990-12-23')
    	 , ('Kiro', 1.99, 120.1, 'm', '2000-04-15')
    	 , ('Maria', 1.70, 60.2, 'f', '1997-03-13')
    
    SELECT * 
      FROM People
    
--Problem 8.Create Table Users
    
    CREATE 
     TABLE Users
         (
    	   Id INT PRIMARY KEY IDENTITY NOT NULL
    	 , Username VARCHAR(30) UNIQUE NOT NULL
    	 , [Password] VARCHAR(26) NOT NULL
    	 , ProfilePicture VARBINARY(MAX)
    	 , CHECK 
    	   (DATALENGTH(ProfilePicture) <= 900 * 1024)
    	 , LastLoginTime DATETIME2
    	 , IsDeleted BIT NOT NULL
         )
    
    INSERT 
      INTO Users(Username, [Password], LastLoginTime, IsDeleted)
    VALUES
    	   ('Dimitar@', 18155, '2022-03-23', 1)
    	 , ('Doncho@', 171682, '2021-01-20', 0)
    	 , ('Darina@', 165555, '2022-12-23', 0)
    	 , ('Kiro@', 1991201, '2020-04-15', 1)
    	 , ('Maria@', 170602, '2022-03-13', 0)
    
    SELECT * 
      FROM Users
    
--Problem 9.Change Primary Key
    
     ALTER
     TABLE Users
      DROP 
CONSTRAINT [PK__Users__3214EC07E7F0A36A]

     ALTER
     TABLE Users
      ADD 
CONSTRAINT [PK__Users__IdUsername]
   PRIMARY
       KEY (Id, Username)

-- Problem 10.Add Check Constraint 

     ALTER
     TABLE Users
	   ADD 
CONSTRAINT CK__Users__PasswordLenght
     CHECK (LEN([Password]) >= 5)

-- Problem 11.Set Default Value of a Field

     ALTER
     TABLE Users
	   ADD 
CONSTRAINT DF__Users__LastLoginTime
   DEFAULT GETDATE() 
       FOR LastLoginTime

-- Problem 12.Set Unique Field

     ALTER
     TABLE Users
      DROP 
CONSTRAINT [PK__Users__IdUsername]

     ALTER
     TABLE Users
      ADD 
CONSTRAINT [PK__Users__Id]
   PRIMARY
       KEY (Id)

	 ALTER
     TABLE Users
	   ADD 
CONSTRAINT CK__Users__UsernameLenght
     CHECK (LEN(Username) >= 3)