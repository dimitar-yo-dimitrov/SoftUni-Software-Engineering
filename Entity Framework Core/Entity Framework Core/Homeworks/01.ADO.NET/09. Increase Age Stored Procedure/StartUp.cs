using System;
using System.Data.SqlClient;
using System.Linq;

namespace _09._Increase_Age_Stored_Procedure
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
                string uspQuery = $"EXEC usp_GetOlder {minion}";
                SqlCommand uspCommand = new SqlCommand(uspQuery, connection);
                uspCommand.ExecuteNonQuery();
            }

            string minionQuery = $@"SELECT Name, Age FROM Minions WHERE Id IN({string.Join(",", minions)})";
            SqlCommand minionCommand = new SqlCommand(minionQuery, connection);
            var reader = minionCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }
    }
}
