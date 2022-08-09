       USE SoftUni

-- 1.Employees with Salary Above 35000

GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 --(@salaryAbove MONEY)
AS
BEGIN
	SELECT FirstName
	     , LastName
	  FROM Employees
     WHERE Salary > 35000  --@salaryAbove
END

GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

-- 2.Employees with Salary Above Number

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber @number DECIMAL(18 ,4)
AS
BEGIN
	SELECT FirstName
	     , LastName
	  FROM Employees
     WHERE Salary >= @number
END

GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100 

-- 3.Town Names Starting With

GO

CREATE OR ALTER PROC usp_GetTownsStartingWith @startCharSymbol VARCHAR(50)
AS
BEGIN
	SELECT t.[Name] AS Town
	  FROM Towns AS t
     WHERE LEFT (t.[Name], LEN(@startCharSymbol)) = @startCharSymbol
END

GO

EXEC dbo.usp_GetTownsStartingWith 'b'

-- 4.Employees from Town

GO

CREATE OR ALTER PROC usp_GetEmployeesFromTown @town VARCHAR(50)
AS
BEGIN
	SELECT e.FirstName 
	     , e.LastName
	  FROM Employees AS e
	  JOIN Addresses AS a
	    ON a.AddressID = e.AddressID
	  JOIN Towns AS t
	    ON a.TownID = t.TownID
     WHERE t.[Name] = @town
END

GO

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'

-- 5.Salary Level Function

GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @levelOfSalary  VARCHAR(10)
	    
		IF (@salary < 30000) 
		SET @levelOfSalary = 'Low'
	     
	ELSE IF (@salary BETWEEN 30000 AND 50000) 
		SET @levelOfSalary = 'Average'
	     
	ELSE IF (@salary > 50000) 
		SET @levelOfSalary = 'High'

     RETURN @levelOfSalary
END

GO

     SELECT e.Salary
	      , dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
	   FROM Employees AS e

-- 6.Employees by Salary Level

GO

CREATE PROC usp_EmployeesBySalaryLevel  @levelOfSalary  VARCHAR(10)
AS
BEGIN
	SELECT FirstName
	     , LastName
	  FROM Employees
     WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

GO

EXEC dbo.usp_EmployeesBySalaryLevel 'High' 

-- 7.Define Function

GO

CREATE FUNCTION ufn_IsWordComprised(@letters VARCHAR(50), @word VARCHAR(50))  
RETURNS INT
AS
BEGIN
	DECLARE @i INT = 0
	  WHILE (@i < LEN(@word))
	  BEGIN
		 IF (CHARINDEX(SUBSTRING(@Word, @i + 1, 1), @letters) = 0)
     RETURN 0
	    SET @i += 1
	    END
     RETURN 1
END

GO

     SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

-- 8.* Delete Employees and Departments

GO

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
	-- 01. Delete employees from EmployeesProjects
	DELETE FROM EmployeesProjects
	      WHERE EmployeeID IN (
	                     SELECT EmployeeID FROM Employees
	                      WHERE DepartmentID = @departmentId)
		            
	-- 02. Set ManagerId to NULL in Employees
	     UPDATE Employees
	        SET ManagerID = NULL
	      WHERE ManagerID IN (
	                     SELECT EmployeeID FROM Employees
	                      WHERE DepartmentID = @departmentId)

	-- 03. Alter column ManagerID in Departments and make it NULLable
	ALTER TABLE Departments
   ALTER COLUMN ManagerID INT

	-- 04. Set ManagerId to NULL in Departments
	     UPDATE Departments
	        SET ManagerID = NULL
	      WHERE ManagerID IN (
	                     SELECT EmployeeID FROM Employees
	                      WHERE DepartmentID = @departmentId)

   -- 05. Delete all employees from current department
    DELETE FROM Employees
          WHERE DepartmentID = @departmentId

   -- 06. Delete current department
    DELETE FROM Departments
          WHERE DepartmentID = @departmentId

   -- 07. Return 0 count If DELETE was succesfull
         SELECT COUNT(*) 
		   FROM Employees
		  WHERE DepartmentID = @departmentId
END

GO

EXEC dbo.usp_DeleteEmployeesFromDepartment 3
