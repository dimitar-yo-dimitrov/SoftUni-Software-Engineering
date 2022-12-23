  CREATE 
DATABASE Orders
	 
	 USE Orders

-- Problem 18.Orders Table

  CREATE 
   TABLE Orders(
         Id INT PRIMARY KEY IDENTITY NOT NULL
	   , ProductName NVARCHAR(50) NOT NULL
	   , OrderDate DATETIME2 NOT NULL)

  INSERT
    INTO Orders(ProductName, OrderDate) 
  VALUES 
         ('Butter', '20160919')
       , ('Milk', '20160930')
       , ('Cheese', '20160904')
       , ('Bread', '20151220')
       , ('Tomatoes', '20150101')
       , ('Tomatoe2', '20150201')
       , ('Tomatoess', '20150401')
       , ('Tomatoe3', '20150128')
       , ('Tomatoe4', '20150628')
       , ('Tomatoe44s', '20150630')
       , ('Tomatoefggs', '20150228')
       , ('Tomatoesytu', '20160228')
       , ('Toyymatddoehys', '20151231')
       , ('Tom443atoes', '20151215')
       , ('Tomat65434foe23', '20151004')

  SELECT ProductName
       , OrderDate
	   , DATEADD(DAY,3, OrderDate) AS [Pay Due]
	   , DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM Orders