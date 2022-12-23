 CREATE DATABASE University  
 
	USE University

 CREATE
  TABLE Majors(   
        MajorID INT PRIMARY KEY IDENTITY
 	  , [Name] VARCHAR(50) NOT NULL)

 CREATE
  TABLE Students(   
        StudentID INT PRIMARY KEY IDENTITY
 	  , StudentNumber VARCHAR(20) NOT NULL
 	  , StudentName VARCHAR(70) NOT NULL
	  , MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL)

 CREATE
  TABLE Payments(   
        PaymentID INT PRIMARY KEY IDENTITY
	  , PaymentDate DATE NOT NULL
	  , PaymentAmount DECIMAL(8, 2) NOT NULL
	  , StudentID INT FOREIGN KEY REFERENCES Students(StudentID))

 CREATE
  TABLE Subjects(   
        SubjectID INT PRIMARY KEY IDENTITY
 	  , SubjectName VARCHAR(70) NOT NULL)

 CREATE
  TABLE Agenda(   
        StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	  , SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
      , PRIMARY KEY(StudentID, SubjectID))



