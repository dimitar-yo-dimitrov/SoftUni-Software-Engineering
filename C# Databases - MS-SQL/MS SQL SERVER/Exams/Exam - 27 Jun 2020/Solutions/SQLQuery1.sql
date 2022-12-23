CREATE DATABASE WMS

GO

USE WMS

GO

-- 01.Database design

   CREATE 
    TABLE Clients(
	      ClientId INT PRIMARY KEY IDENTITY
	    , FirstName VARCHAR(50) NOT NULL
        , LastName VARCHAR(50) NOT NULL
        , Phone CHAR(12) NOT NULL,) 

   CREATE 
    TABLE Mechanics(
	      MechanicId INT PRIMARY KEY IDENTITY
	    , FirstName VARCHAR(50) NOT NULL
        , LastName VARCHAR(50) NOT NULL
        , [Address] VARCHAR(255) NOT NULL)

   CREATE 
    TABLE Models(
	      ModelId INT PRIMARY KEY IDENTITY
	    , [Name] VARCHAR(50) UNIQUE NOT NULL)
   
   CREATE 
    TABLE Jobs(
	      JobId INT PRIMARY KEY IDENTITY
        , ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL
        , [Status]  VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN('Pending', 'In Progress', 'Finished'))
		, ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL       
        , MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId)        
		, IssueDate DATETIME2 NOT NULL		
		, FinishDate DATETIME2)


   CREATE 
    TABLE Orders(
	      OrderId INT PRIMARY KEY IDENTITY
	    , JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL       
        , IssueDate DATETIME2
        , Delivered BIT NOT NULL)

   CREATE 
    TABLE Vendors(
	      VendorId INT PRIMARY KEY IDENTITY
	    , [Name] VARCHAR(50) UNIQUE NOT NULL)

   CREATE 
    TABLE Parts(
	      PartId INT PRIMARY KEY IDENTITY
        , SerialNumber VARCHAR(50) UNIQUE NOT NULL
        , [Description]  VARCHAR(255) 
		, Price MONEY CHECK(Price > 0) NOT NULL      
        , VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL        
		, StockQty INT DEFAULT 0 CHECK(StockQty >= 0) NOT NULL)
		
   CREATE 
    TABLE OrderParts(
	      OrderId INT FOREIGN KEY REFERENCES Orders(OrderId)
	    , PartId INT FOREIGN KEY REFERENCES Parts(PartId)     
        , PRIMARY KEY(OrderId, PartId)
		, Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL)


   CREATE 
    TABLE PartsNeeded(
	      JobId INT FOREIGN KEY REFERENCES Jobs(JobId)
	    , PartId INT FOREIGN KEY REFERENCES Parts(PartId)      
        , PRIMARY KEY(JobId, PartId)
		, Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL)


-- 02. Insert

	  INSERT
		INTO Clients([FirstName], [LastName], Phone)
	  VALUES 
			 ('Teri', 'Ennaco', '570-889-5187')
           , ('Merlyn', 'Lawler', '201-588-7810')
           , ('Georgene', 'Montezuma', '925-615-5185')
           , ('Jettie', 'Mconnell', '908-802-3564')
           , ('Lemuel', 'Latzke', '631-748-6479')
           , ('Melodie', 'Knipp', '805-690-1682')
           , ('Candida', 'Corbley', '908-275-8357')


	  INSERT
		INTO Parts([SerialNumber], [Description], Price, VendorId)
	  VALUES 
			 ('WP8182119', 'Door Boot Seal', 117.86, 2)
		   , ('W10780048', 'Suspension Rod', 42.81, 1)
		   , ('W10841140', 'Silicone Adhesive' , 6.77, 4)
		   , ('WPY055980', 'High Temperature Adhesive', 13.94, 3)


-- 03. Update

      UPDATE Jobs
	     SET MechanicId = 3, [Status] = 'In Progress'
	    FROM Jobs
       WHERE [Status] = 'Pending'

-- 04. Delete
      DELETE
  	    FROM OrderParts
       WHERE OrderId = 
     (SELECT OrderId FROM Orders WHERE OrderId = 19)

      DELETE 
	    FROM Orders
	   WHERE OrderId = 19

-- 05. Mechanic Assignments

      SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic 
           , j.Status
           , j.IssueDate
        FROM Mechanics AS m
        JOIN Jobs AS j
          ON m.MechanicId = j.MechanicId
    ORDER BY m.MechanicId, j.IssueDate, j.JobId

-- 06. Current Clients

      SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client 
           , DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going]
           , j.Status
        FROM Clients AS c
        JOIN Jobs AS j
          ON c.ClientId = j.ClientId
       WHERE j.Status IN('Pending', 'In Progress')
    ORDER BY [Days going] DESC, c.ClientId

-- 07. Mechanic Performance

      SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic 
           , AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
        FROM Mechanics AS m
        JOIN Jobs AS j
          ON m.MechanicId = j.MechanicId
	   WHERE j.Status IN('Finished')
    GROUP BY m.MechanicId, m.FirstName, m.LastName
    ORDER BY m.MechanicId

-- 08. Available Mechanics

      SELECT 
	         CONCAT(m.FirstName, ' ', m.LastName) AS Available 
        FROM Mechanics AS m
   LEFT JOIN Jobs AS j
          ON m.MechanicId = j.MechanicId
	   WHERE j.JobId IS NULL 
	      OR 'Finished' = 
	     ALL (SELECT j.[Status] 
		        FROM Jobs AS j 
			   WHERE m.MechanicId = j.MechanicId)
    GROUP BY m.FirstName, m.LastName, m.MechanicId
    ORDER BY m.MechanicId

-- 09. Past Expenses

      SELECT j.JobId
	       , ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
        FROM Jobs AS j
   LEFT JOIN Orders AS o
          ON j.JobId = o.JobId
   LEFT JOIN OrderParts AS op
          ON op.OrderId = o.OrderId
   LEFT JOIN Parts AS p
		  ON op.PartId = p.PartId
	   WHERE j.[Status] IN('Finished')
    GROUP BY j.JobId   
	ORDER BY Total DESC, j.JobId

-- 10. Missing Parts

      SELECT p.PartId
	       , p.[Description]
	       , ISNULL(pn.Quantity, 0) AS [Required]
	       , ISNULL(p.StockQty, 0) AS [In Stock]
	       , ISNULL(IIF(o.Delivered = 0, op.Quantity, 0), 0) AS Ordered
        FROM Parts AS p
   LEFT JOIN PartsNeeded AS pn
          ON p.PartId = pn.PartId
   LEFT JOIN OrderParts AS op
          ON p.PartId = op.PartId
   LEFT JOIN Jobs AS j
          ON j.JobId = pn.JobId
   LEFT JOIN Orders AS o
		  ON op.OrderId = o.OrderId
	   WHERE j.[Status] <> 'Finished'
	     AND pn.Quantity > ISNULL(
		                          (p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0)), 0)
	ORDER BY p.PartId

-- 11. Place Order
GO

CREATE PROC usp_PlaceOrder(@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT) AS
BEGIN
	DECLARE @JobStatus VARCHAR(MAX) = (SELECT Status FROM Jobs WHERE JobId = @JobId)
	DECLARE @JobExists BIT = (SELECT COUNT(JobId) FROM Jobs WHERE JobId = @JobId)
	DECLARE @PartExists BIT = (SELECT COUNT(SerialNumber) FROM Parts WHERE SerialNumber = @SerialNumber)

	IF(@Quantity <= 0)
	BEGIN;
		THROW 50012, 'Part quantity must be more than zero!' , 1
	END

	IF(@JobStatus = 'Finished')
	BEGIN;
		THROW 50011, 'This job is not active!', 1
	END

	IF(@JobExists = 0)
	BEGIN;
		THROW 50013, 'Job not found!', 1
	END

	IF(@PartExists = 0)
	BEGIN;
		THROW 50014, 'Part not found!', 1
	END

	DECLARE @OrderForJobExists INT = 
	(
		SELECT COUNT(o.OrderId) FROM Orders AS o
		WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderForJobExists = 0)
	BEGIN
		INSERT INTO Orders VALUES
		(@JobId, NULL, 0)
	END

	DECLARE @OrderId INT = 
	(
		SELECT o.OrderId FROM Orders AS o
		WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderId > 0 AND @PartExists = 1 AND @Quantity > 0)
	BEGIN
		DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
		DECLARE @PartExistsInOrder INT = (SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)

		IF(@PartExistsInOrder > 0)
		BEGIN
			UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderId AND PartId = @PartId
		END
		ELSE
		BEGIN
			INSERT INTO OrderParts VALUES
			(@OrderId, @PartId, @Quantity)
		END
	END
END

-- 12. Cost of Order
GO

CREATE OR ALTER FUNCTION udf_GetCost(@JobId INT) 
RETURNS DECIMAL(12,2)
AS
BEGIN
	DECLARE @Result DECIMAL(12,2) = ISNULL((SELECT SUM(p.Price) AS Result 
	                                  FROM Orders AS o
									  JOIN OrderParts AS op
									    ON o.OrderId = op.OrderId
                                      JOIN Parts AS p
									    ON p.PartId = op.PartId
									 WHERE o.JobId = @JobId), 0)
        
	 RETURN @Result
END

GO

SELECT dbo.udf_GetCost(1)