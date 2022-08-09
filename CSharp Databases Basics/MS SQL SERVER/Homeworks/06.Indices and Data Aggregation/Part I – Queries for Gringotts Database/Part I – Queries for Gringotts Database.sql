     USE Gringotts

-- 1.Records’ Count

  SELECT COUNT(*)
    FROM WizzardDeposits

-- 2.Longest Magic Wand

  SELECT MAX(w.MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits AS w

-- 3.Longest Magic Wand Per Deposit Groups

  SELECT w.DepositGroup
       , MAX(w.MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

-- 4.Smallest Deposit Group Per Magic Wand Size

  SELECT 
  TOP(2) w.DepositGroup
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

-- 5.Deposits Sum

  SELECT w.DepositGroup
       , SUM(w.DepositAmount)
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

-- 6.Deposits Sum for Ollivander Family

  SELECT w.DepositGroup
       , SUM(w.DepositAmount)
    FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup

-- 7.Deposits Filter

  SELECT w.DepositGroup
       , SUM(w.DepositAmount)
    FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
  HAVING SUM(w.DepositAmount) < 150000
ORDER BY SUM(w.DepositAmount) DESC

-- 8.Deposit Charge

  SELECT w.DepositGroup
       , w.MagicWandCreator
       , MIN(w.DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

-- 9.Age Groups

  SELECT w.AgeGroup
       , COUNT(w.AgeGroup) AS WizardCount
    FROM 
	   (
  SELECT CASE WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
              WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
              WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
              WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
              WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
              WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
              WHEN Age >= 61 THEN '[61+]'
            END AS AgeGroup
	FROM WizzardDeposits) AS w
GROUP BY w.AgeGroup

-- 10.First Letter

  SELECT 
DISTINCT LEFT(w.FirstName, 1) AS FirstLetter
    FROM WizzardDeposits AS w
   WHERE w.DepositGroup = 'Troll Chest'

-- 11.Average Interest

  SELECT w.DepositGroup
       , w.IsDepositExpired
	   , AVG(w.DepositInterest) AS AverageInterest	
    FROM WizzardDeposits AS w
   WHERE w.DepositStartDate > '1985-01-01'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, w.IsDepositExpired

-- 12.* Rich Wizard, Poor Wizard

  SELECT SUM(Host.DepositAmount - Guest.DepositAmount) AS SumDifference
    FROM WizzardDeposits AS Host
    JOIN WizzardDeposits AS Guest 
	  ON Host.Id + 1 = Guest.Id


