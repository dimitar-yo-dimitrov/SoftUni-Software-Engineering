using System;
using Microsoft.Data.SqlClient;

namespace _02._Villain_Names
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection
                ("Server=.;Integrated Security=true;Database=MinionsDB;Encrypt=false");
            
            connection.Open();
            
            string query = "SELECT CONCAT(Name, ' - ', COUNT(*))" +
                           " FROM Villains v" +
                           " JOIN MinionsVillains mv ON mv.VillainId = v.Id" +
                           " GROUP BY Name HAVING COUNT(*) > 3" +
                           " ORDER BY COUNT(VillainId) DESC";
            
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
        }
    }
}
