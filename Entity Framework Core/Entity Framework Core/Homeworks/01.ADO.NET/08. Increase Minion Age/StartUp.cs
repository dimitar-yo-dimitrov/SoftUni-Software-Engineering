using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08._Increase_Minion_Age
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minions = Console.ReadLine()!
                .Split()
                .Select(int.Parse)
                .ToArray();

            using SqlConnection connection = new SqlConnection
                ("Server=.;Integrated Security=true;Database=MinionsDB;Encrypt=false");
            connection.Open();

            foreach (var minion in minions)
            {
                string minionQuery = $@"UPDATE Minions SET Age += 1 WHERE Id = {minion}";
                SqlCommand minionCommand = new SqlCommand(minionQuery, connection);
                minionCommand.ExecuteNonQuery();

                string updateQuery = $@"UPDATE Minions SET Name = UPPER(SUBSTRING(Name,1,1)) + SUBSTRING(Name, 2, LEN(Name) - 1) WHERE Id = {minion}";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.ExecuteNonQuery();
            }

            string readerQuery = "SELECT Name, Age FROM Minions";
            SqlCommand readerCommand = new SqlCommand(readerQuery, connection);
            var reader = readerCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}
