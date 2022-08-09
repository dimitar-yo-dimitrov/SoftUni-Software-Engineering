 CREATE DATABASE EntityRelations
 
	USE EntityRelations

 CREATE
  TABLE Manufacturers(   
        ManufacturerID INT PRIMARY KEY IDENTITY
 	  , [Name] VARCHAR(30) NOT NULL
 	  , EstablishedOn DATE NOT NULL)

 INSERT INTO Manufacturers([Name], EstablishedOn)
 VALUES ('BMV', '07/03/1916')
      , ('Tesla', '01/01/2003')
      , ('Lada', '01/05/1966')

 CREATE
  TABLE Models(   
        ModelID INT PRIMARY KEY IDENTITY(101, 1)
 	  , [Name] NVARCHAR(30) NOT NULL
	  , ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL)

 INSERT INTO Models([Name], ManufacturerID)
 VALUES ('X1', 1)
      , ('i6', 1)
      , ('Moderl S', 2)
      , ('Moderl X', 2)
      , ('Moderl 3', 2)
      , ('Nova, 1', 3)



