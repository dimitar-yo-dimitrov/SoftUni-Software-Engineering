using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Shopping_Spree
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<string> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<string> BagOfProducts
        {
            get { return this.bagOfProducts; }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }

            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
                this.bagOfProducts.Add(product.Name);
            }
        }

        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.bagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }

            else
            {
                person += string.Join(", ", this.bagOfProducts);
            }

            return person;
        }
    }

    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var persons = new List<Person>();
            var products = new List<Product>();

            try
            {
                var peopleInput = Console.ReadLine()
                    .Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                var productsInput = Console.ReadLine()
                    .Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < peopleInput.Length; i += 2)
                {
                    var name = peopleInput[i];
                    var money = decimal.Parse(peopleInput[i + 1]);

                    var person = new Person(name, money);

                    persons.Add(person);
                }

                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    var name = productsInput[i];
                    var cost = decimal.Parse(productsInput[i + 1]);

                    var product = new Product(name, cost);

                    products.Add(product);
                }

                while (true)
                {
                    string line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    string[] parts = line
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Person buyer = persons.FirstOrDefault(x => x.Name == parts[0]);
                    Product product = products.FirstOrDefault(y => y.Name == parts[1]);

                    buyer.BuyProduct(product);
                }

                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
