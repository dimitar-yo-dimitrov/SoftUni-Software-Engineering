using Microsoft.Data.SqlClient;

namespace _01._Initial_Setup
{

    internal class StartUp
    {
        public static void Main(string[] args)
        {
            string createQuery = "CREATE DATABASE MinionsDB";
            
            using (SqlConnection connection = new SqlConnection
                       ("Server=.;Integrated Security=true;Database=master;Encrypt=false"))
            {
                connection.Open();

                //Create DATABASE
                SqlCommand command = new SqlCommand(createQuery, connection);
                command.ExecuteNonQuery();
            }

            string tableCountries = "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY," +
                                    " Name VARCHAR(100) NOT NULL)";

            string tableTowns = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY," +
                                " CountryCode INT REFERENCES Countries(Id) NOT NULL)";

            string tableMinions = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50) NOT NULL," +
                                  " Age INT, TownId INT REFERENCES Towns(Id) NOT NULL)";

            string tableEvilnessFactors = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY," +
                                          " Name VARCHAR(100) NOT NULL)";

            string tableVillains = "CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY," +
                                   " Name VARCHAR(100) NOT NULL, EvilnessFactorId INT REFERENCES EvilnessFactors(Id))";
           
            string tableMinionsVillains = "CREATE TABLE MinionsVillains(MinionId INT REFERENCES Minions(Id)," +
                                          " VillainId INT REFERENCES Villains(Id), PRIMARY KEY(MinionId, VillainId))";
            
            string insertIntoCountriesQueryText =
                @"INSERT INTO Countries (Name) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";

            string insertIntoTownsQueryText =
                @"INSERT INTO Towns (Name, CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
           
            string insertIntoMinionsQueryText =
                @"INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
            
            string insertIntoEvilnessFactorsQueryText =
                @"INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
            
            string insertIntoVillainsQueryText =
                @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
           
            string insertIntoMinionsVillainsQueryText = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
           
            using (SqlConnection connection = new SqlConnection
                       ("Server=.;Integrated Security=true;Database=MinionsDB;Encrypt=false"))
            {
                connection.Open();

                // Create Table Countries
                SqlCommand tableCountriesCommand = new SqlCommand(tableCountries, connection);
                tableCountriesCommand.ExecuteNonQuery();

                // Create Table Towns
                SqlCommand tableTownsCommand = new SqlCommand(tableTowns, connection);
                tableTownsCommand.ExecuteNonQuery();

                // Create Table Minions
                SqlCommand tableMinionsCommand = new SqlCommand(tableMinions, connection);
                tableMinionsCommand.ExecuteNonQuery();

                // Create Table EvilnessFactors
                SqlCommand tableEfCommand = new SqlCommand(tableEvilnessFactors, connection);
                tableEfCommand.ExecuteNonQuery();

                // Create Table Villains
                SqlCommand tableVillainsCommand = new SqlCommand(tableVillains, connection);
                tableVillainsCommand.ExecuteNonQuery();

                // Create Table MinionsVillains
                SqlCommand tableMVCommand = new SqlCommand(tableMinionsVillains, connection);
                tableMVCommand.ExecuteNonQuery();

                //Insert Into Table Countries
                SqlCommand insertIntoCountriesCommand = new SqlCommand(insertIntoCountriesQueryText, connection);
                insertIntoCountriesCommand.ExecuteNonQuery();

                //Insert Into Table Towns
                SqlCommand insertIntoTownsCommand = new SqlCommand(insertIntoTownsQueryText, connection);
                insertIntoTownsCommand.ExecuteNonQuery();

                //Insert Into Table Minions
                SqlCommand insertIntoMinionsCommand = new SqlCommand(insertIntoMinionsQueryText, connection);
                insertIntoMinionsCommand.ExecuteNonQuery();

                //Insert Into Table EvilnessFactors
                SqlCommand insertIntoEvilnessFactorsCommand =
                    new SqlCommand(insertIntoEvilnessFactorsQueryText, connection);
                insertIntoEvilnessFactorsCommand.ExecuteNonQuery();

                //Insert Into Table Villains
                SqlCommand insertIntoVillainsCommand = new SqlCommand(insertIntoVillainsQueryText, connection);
                insertIntoVillainsCommand.ExecuteNonQuery();

                // Insert Into Table MinionsVillains
                SqlCommand insertIntoMinionsVillainsCommand =
                    new SqlCommand(insertIntoMinionsVillainsQueryText, connection);
                insertIntoMinionsVillainsCommand.ExecuteNonQuery();
            }
        }
    }
}
