--  Problem 01.Create Database

CREATE DATABASE [Minions]

USE [Minions]

--  Problem 02.Create Tables

GO

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL,
)

--  Problem 03.Alter Minions Table

ALTER TABLE [Minions]
ADD 
	[TownId] 
	INT FOREIGN KEY REFERENCES 
	[Towns]([Id]) NOT NULL

GO

--  Problem 04.Insert Records into Both Tables

GO

INSERT INTO [Towns] VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

SELECT * FROM [Towns]

INSERT INTO [Minions] VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

SELECT * FROM [Minions]

GO

--  Problem 05.Truncate Table Minions

TRUNCATE TABLE [Minions]

--  Problem 06.Drop All Tables

DROP TABLE [Minions]
DROP TABLE [Towns]


--  Problem 07. Create Table People

CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (
	DATALENGTH(
	[Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK (
	[Gender] = 'm' 
	OR 
	[Gender] = 'f'),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)