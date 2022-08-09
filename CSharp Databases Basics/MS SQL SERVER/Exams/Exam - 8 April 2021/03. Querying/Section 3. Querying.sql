USE [Service]

-- 05.Unassigned Reports

SELECT r.[Description], FORMAT(r.OpenDate, 'dd-MM-yyyy')
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, r.[Description]

-- 06. Reports & Categories
 
SELECT r.[Description], c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c
  ON r.CategoryId = c.Id
WHERE r.CategoryId IS NOT NULL
ORDER BY r.[Description], CategoryName

-- 07.Most Reported Category

SELECT TOP(5) c.[Name] AS CategoryName
, COUNT(r.CategoryId) AS ReportsNumber
FROM Categories AS	c
JOIN Reports AS r
  ON r.CategoryId = c.Id
GROUP BY c.[Name], r.CategoryId
ORDER BY ReportsNumber DESC, CategoryName

-- 08.Birthday Report

SELECT u.Username, c.[Name] AS CategoryName 
FROM Users AS u
LEFT JOIN Reports AS r 
ON u.Id = r.UserId
JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate) AND
      DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate) 
ORDER BY u.Username, CategoryName

-- 09.User per Employee

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(DISTINCT(r.UserId)) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r
ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC, FullName

-- 10. Full Info

SELECT
	 CASE 
	     WHEN COALESCE(e.FirstName, e.LastName) IS NOT NULL 
		 THEN CONCAT(e.FirstName, ' ', e.LastName) 
		 ELSE 'None'
     END AS Employee
, ISNULL(d.[Name], 'None') AS Department
, ISNULL(c.[Name], 'None') AS Category
, ISNULL(r.[Description], 'None') AS [Description]
, ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate
, ISNULL(s.[Label], 'None') AS [Status]
, ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees  AS e ON e.Id = r.EmployeeId
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN Departments  AS d ON d.Id = e.DepartmentId
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, [Description], OpenDate, [Status], [User] 


