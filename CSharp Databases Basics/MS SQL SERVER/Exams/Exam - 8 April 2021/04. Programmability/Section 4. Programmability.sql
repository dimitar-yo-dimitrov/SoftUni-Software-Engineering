USE [Service]

-- 11.Hours to Complete

GO

CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
	DECLARE @Result INT

		 IF @StartDate IS NULL OR @EndDate IS NULL
	    
		         SET @Result = 0 

		 ELSE
		
	             SET @Result = ABS(DATEDIFF(HOUR, @StartDate, @EndDate)) 
        
		RETURN @Result
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO

-- 12. Assign Employee

CREATE PROC usp_AssignEmployeeToReport @EmployeeId INT, @ReportId INT 
AS
BEGIN
    BEGIN TRANSACTION
			DECLARE @EmpDepart INT = (
			SELECT e.DepartmentId FROM Employees AS e
			WHERE e.Id = @EmployeeId)

			DECLARE @CategryId INT = (
			SELECT r.CategoryId FROM Reports AS r
			WHERE r.Id = @ReportId)

			DECLARE @ReportDepart INT = (
			SELECT c.DepartmentId FROM Categories AS c 
			WHERE c.Id = @CategryId)

			IF @EmpDepart <> @ReportDepart
			BEGIN 
				ROLLBACK;
				THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
			END

			UPDATE Reports 
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
	COMMIT
END

GO

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2