using System;
using Microsoft.Data.SqlClient;

namespace _03._Minion_Names
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection
             ("Server=.;Integrated Security=true;Database=MinionsDB;Encrypt=false");

            connection.Open();

            int input = int.Parse(Console.ReadLine() ?? string.Empty);

            string villainQuery =
                              @$"SELECT 
	                                   CASE
		                               WHEN (SELECT COUNT(*) FROM Villains WHERE Id = {input}) > 0 
		                                  THEN (SELECT CONCAT('Villain: ', Name) FROM Villains WHERE Id = {input})
		                               ELSE 'No villain with ID {input} exists in the database.'
	                                   END AS [Villian]";

            SqlCommand villainCommand = new SqlCommand(villainQuery, connection);

            string villainOutput = (string)villainCommand.ExecuteScalar();

            Console.WriteLine(villainOutput);

            string minionQuery =
                $@"SELECT COUNT(*) FROM Villains WHERE Id = {input}";

            SqlCommand minionCommand = new SqlCommand(minionQuery, connection);

            int minionOutput = (int)minionCommand.ExecuteScalar();

            switch (minionOutput)
            {
                case 0 when !villainOutput.StartsWith("No"):
                    Console.WriteLine("(no minions)");
                    break;

                case > 0:
                    int count = 1;
                    string readerQuery =
                                     $@"SELECT Name, Age
	                                                     FROM Minions m
	                                                     JOIN MinionsVillains mv ON mv.MinionId = m.Id
	                                                     WHERE VillainId = {input}
	                                                     ORDER BY Name";
                    SqlCommand readerCommand = new SqlCommand(readerQuery, connection);
                    SqlDataReader reader = readerCommand.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{count}. {reader[0]} {reader[1]}");
                            count++;
                        }

                        break;
                    }
            }
        }
    }
}
