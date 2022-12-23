--  Problem 13.Movies Database    
	
	CREATE
  DATABASE Movies 

       USE Movies 

    CREATE
	 TABLE Directors 
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , DirectorName NVARCHAR(200) NOT NULL
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Directors(DirectorName, Notes)
    VALUES
    	   ('Dimitar', 'Notes...')
    	 , ('Doncho', 'Notes...')
    	 , ('Darina', 'Notes...')
    	 , ('Kiro', 'Notes...')
    	 , ('Maria', 'Notes...')
    
	CREATE
	 TABLE Genres  
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , GenreName NVARCHAR(200) NOT NULL
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Genres(GenreName, Notes)
    VALUES
    	   ('Action', 'Notes...')
    	 , ('Comedy', 'Notes...')
    	 , ('Fantasy', 'Notes...')
    	 , ('Drama', 'Notes...')
    	 , ('Animation', 'Notes...')

    CREATE
	 TABLE Categories   
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , CategoryName NVARCHAR(200) NOT NULL
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Categories(CategoryName, Notes)
    VALUES
    	   ('A', 'Notes...')
    	 , ('B', 'Notes...')
    	 , ('C', 'Notes...')
    	 , ('D', 'Notes...')
    	 , ('E', 'Notes...')

	CREATE
	 TABLE Movies    
	     (
		   Id INT PRIMARY KEY IDENTITY NOT NULL
		 , Title NVARCHAR(200) NOT NULL
		 , DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL
		 , CopyrightYear DATE
		 , [Length] INT
		 , GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
		 , CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
		 , Rating INT
		 , Notes NVARCHAR(500)
		 )

	INSERT 
      INTO Movies(Title, DirectorId, [Length], GenreId, CategoryId, Rating, Notes)
    VALUES
    	   ('Avatar', 1, 180, 3, 5, 10, 'Notes...')
    	 , ('Avengers: Endgame', 2, 160, 1, 4, 10, 'Notes...')
    	 , ('Avengers: Infinity War', 3, 150, 1, 3, 10, 'Notes...')
    	 , ('The Lion King', 4, 90, 5, 2, 10, 'Notes...')
    	 , ('Aladdin', 5, 93, 2, 1, 7, 'Notes...')
    
    SELECT * 
      FROM Movies
