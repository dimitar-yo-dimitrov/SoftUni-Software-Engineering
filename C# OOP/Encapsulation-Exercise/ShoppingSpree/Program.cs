using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                string[] inputPeople = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string[] inputProducts = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentPerson in inputPeople)
                {
                    string[] values = currentPerson
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = values[0];
                    decimal money = decimal.Parse(values[1]);

                    Person person = new Person(name, money);

                    if (!people.ContainsKey(name))
                    {
                        people.Add(person.Name, person);
                    }
                }

                foreach (var currentProduct in inputProducts)
                {
                    string[] values = currentProduct
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = values[0];
                    decimal cost = decimal.Parse(values[1]);

                    Product product = new Product(name, cost);

                    products.Add(product.Name, product);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = people[parts[0]];
                Product product = products[parts[1]];
                
                try
                {
                    Console.WriteLine(person.AddProduct(product));
                }
               
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}
