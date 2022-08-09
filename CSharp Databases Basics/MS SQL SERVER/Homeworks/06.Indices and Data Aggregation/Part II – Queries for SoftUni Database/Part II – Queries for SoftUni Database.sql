     USE SoftUni

-- 13.Departments Total Salaries

  SELECT e.DepartmentID
       , SUM(e.Salary) AS TotalSalary
    FROM Employees AS e
GROUP BY e.DepartmentID 

-- 14.Employees Minimum Salaries

  SELECT e.DepartmentID
       , MIN(e.Salary) AS MinimumSalary
    FROM Employees AS e
   WHERE e.HireDate > '01/01/2000' AND e.DepartmentID IN(2, 5, 7) 
GROUP BY e.DepartmentID 

-- 15.Employees Average Salaries

  SELECT * 
    INTO NewTable
	FROM Employees
   WHERE Salary > 30000

  DELETE 
    FROM NewTable
   WHERE ManagerID = 42

  UPDATE NewTable
     SET Salary += 5000
   WHERE DepartmentID = 1

  SELECT DepartmentID
       , AVG(Salary) AS AverageSalary
    FROM NewTable
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries

  SELECT e.DepartmentID
       , MAX(e.Salary) AS MaxSalary
    FROM Employees AS e
GROUP BY e.DepartmentID 
  HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

-- 17.Employees Count Salaries

  SELECT  COUNT(*) AS [Count]
    FROM Employees AS e 
   WHERE e.ManagerID IS NULL
  
-- 18.*3rd Highest Salary

  SELECT DepartmentID
       , Salary AS ThirdHighestSalary
    FROM 
	   (
  SELECT DepartmentID
       , Salary
	   , DENSE_RANK() OVER(
	     PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM Employees
GROUP BY DepartmentID
       , Salary
	   ) AS RankSalaryByDepartment
   WHERE [Rank] = 3

-- 19.**Salary Challenge

  SELECT 
 TOP(10) em.FirstName
       , em.LastName
       , em.DepartmentID
    FROM Employees AS em
   WHERE em.Salary >
	   ( 
  SELECT AVG(e.Salary) 
    FROM Employees AS e
GROUP BY e.DepartmentID
  HAVING e.DepartmentID = em.DepartmentID
       ) 
ORDER BY em.DepartmentID 

