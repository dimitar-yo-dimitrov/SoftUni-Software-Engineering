   CREATE DATABASE Zoo

       GO

      USE Zoo

	   GO

-- 01.Database design

   CREATE 
    TABLE Owners(
	      Id INT PRIMARY KEY IDENTITY
        , [Name] VARCHAR(50) NOT NULL
        , PhoneNumber VARCHAR(15) NOT NULL
        , [Address] VARCHAR(50))

   CREATE 
    TABLE AnimalTypes(
	      Id INT PRIMARY KEY IDENTITY
        , AnimalType VARCHAR(30) NOT NULL)

   CREATE 
    TABLE Cages(
	      Id INT PRIMARY KEY IDENTITY
        , AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL)

   CREATE 
    TABLE Animals(
	      Id INT PRIMARY KEY IDENTITY
        , [Name] VARCHAR(30) NOT NULL
        , BirthDate DATE NOT NULL
        , OwnerId INT FOREIGN KEY REFERENCES Owners(Id)       
		, AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL)


   CREATE
    TABLE AnimalsCages(
	      CageId INT FOREIGN KEY REFERENCES Cages(Id)
	    , AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
		, PRIMARY KEY(CageId, AnimalId)) 

   CREATE 
    TABLE VolunteersDepartments(
	      Id INT PRIMARY KEY IDENTITY
        , DepartmentName VARCHAR(30) NOT NULL)

   CREATE 
    TABLE Volunteers(
	      Id INT PRIMARY KEY IDENTITY
        , [Name] VARCHAR(50) NOT NULL
        , PhoneNumber VARCHAR(15) NOT NULL
        , [Address] VARCHAR(50)
		, AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
		, DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id))

-- 02. Insert

      INSERT
		INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId)
	  VALUES 
		  ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1)
        , ('Dimitur Stoev', '0877564223', null, 42, 4)
        , ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7)
        , ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8)
        , ('Boryana Mileva', '0888112233', null, 31, 5)


	  INSERT
		INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId)
	  VALUES 
			  ('Giraffe', '2018-09-21', 21, 1)
			, ('Harpy Eagle', '2015-04-17', 15, 3)
			, ('Hamadryas Baboon', '2017-11-02', null, 1)
			, ('Tuatara', '2021-06-30', 2, 4)

-- 03. Update

SELECT * FROM Owners
WHERE Name = 'Kaloqn Stoqnov'

UPDATE Animals
SET OwnerId = 4
FROM Animals
WHERE OwnerId IS NULL

-- 04. Delete
      
	  DELETE v
	    FROM Volunteers AS v
		JOIN VolunteersDepartments AS vd
		  ON v.DepartmentId = vd.Id
	   WHERE DepartmentName = 'Education program assistant'
	  
	  DELETE 
	    FROM VolunteersDepartments
	   WHERE DepartmentName = 'Education program assistant'

-- 05. Volunteers

   SELECT v.Name, v.PhoneNumber, v.Address, v.AnimalId, v.DepartmentId
     FROM Volunteers AS v
 ORDER BY v.Name,v.AnimalId, v.DepartmentId 

 -- 06. Animals data

 SELECT a.Name,aty.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy')
FROM Animals AS a
JOIN AnimalTypes AS aty
		  ON a.AnimalTypeId = aty.Id
ORDER BY a.Name

-- 07. Owners and Their Animals

SELECT TOP(5) o.[Name] AS [Owner]
      , COUNT(a.AnimalTypeId) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a
		  ON a.OwnerId = o.Id
		 GROUP BY o.Id, o.Name
ORDER BY CountOfAnimals DESC, [Owner]

-- 08. Owners, Animals and Cages

     SELECT CONCAT(o.Name
	        , '-', a.Name) AS OwnersAnimals
			, o.PhoneNumber
			, c.Id AS CageId
     FROM Owners AS o
         JOIN Animals AS a
		  ON a.OwnerId = o.Id
		  JOIN AnimalTypes AS aty
		  ON a.AnimalTypeId = aty.Id
		  JOIN AnimalsCages AS ac
		  ON ac.AnimalId = a.Id
		   JOIN Cages AS c
		  ON ac.CageId = c.Id
		  WHERE aty.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC 

-- 09. Volunteers in Sofia

SELECT v.Name, v.PhoneNumber, SUBSTRING(v.Address, 8, LEN(v.Address)) AS Address
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd
  ON v.DepartmentId = vd.Id
WHERE DepartmentName = 'Education program assistant' AND v.Address LIKE '%Sofia%'
ORDER BY v.Name

-- 10. Animals for Adoption

     SELECT  a.Name
	        , YEAR(a.BirthDate) AS BirthYea
			, aty.AnimalType AS AnimalType
     FROM Animals AS a
		 LEFT JOIN AnimalTypes AS aty
		  ON a.AnimalTypeId = aty.Id
		 
		  WHERE a.OwnerId IS NULL AND aty.AnimalType IN ('Mammals', 'Fish','Reptiles','Amphibians','Invertebrates') 
		  AND DATEDIFF(YEAR, a.BirthDate, '2022-01-01') < 5
ORDER BY a.Name 

-- 11. All Volunteers in a Department

GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	    SET @Result =
	      (
	 SELECT COUNT(v.Id)
        FROM Volunteers AS v
		JOIN VolunteersDepartments AS vd
		  ON v.DepartmentId = vd.Id
	   WHERE DepartmentName = @VolunteersDepartment
		  )
		 IF @Result IS NULL
	  BEGIN
	    SET @Result = 0 
	    END
     RETURN @Result
END

GO

SELECT dbo.udf_GetVolunteersCountFromADepartment('Education program assistant')

GO

-- 12. Animals with Owner or Not

CREATE PROC usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
BEGIN
    SELECT a.Name
         , ISNULL(o.Name, 'For adoption') AS OwnersName
      FROM Animals AS a
	 LEFT JOIN Owners AS o
	    ON a.OwnerId = o.Id 
		WHERE a.Name = @AnimalName
      
END

GO

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'


