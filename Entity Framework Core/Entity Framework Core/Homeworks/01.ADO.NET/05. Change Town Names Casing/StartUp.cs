using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05._Change_Town_Names_Casing
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using SqlConnection connection = new SqlConnection
                ("Server=.;Integrated Security=true;Database=MinionsDB;Encrypt=false");

            connection.Open();

            string countryCodeQuery = $@"SELECT ISNULL((SELECT TOP(1) Id FROM Countries WHERE Name = '{country}'), 0)";
            SqlCommand countryCommand = new SqlCommand(countryCodeQuery, connection);
            int countryId = (int)countryCommand.ExecuteScalar();

            string countQuery = $@"SELECT COUNT(*) FROM Towns WHERE CountryCode = {countryId}";
            SqlCommand countCommand = new SqlCommand(countQuery, connection);
            int? count = (int)countCommand.ExecuteScalar();

            if (count == 0 || countryId == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            List<string> countries = new List<string>();

            string upperQuery = $@"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = {countryId}";
            SqlCommand upperCommand = new SqlCommand(upperQuery, connection);
            upperCommand.ExecuteNonQuery();

            string readerQuery = $@"SELECT Name FROM Towns WHERE CountryCode = {countryId}";
            SqlCommand readerCommand = new SqlCommand(readerQuery, connection);
            var reader = readerCommand.ExecuteReader();

            while (reader.Read())
            {
                countries.Add(reader[0].ToString());
            }

            Console.WriteLine($"[{string.Join(", ", countries)}]");
        }
    }
}
