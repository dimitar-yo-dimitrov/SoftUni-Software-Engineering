using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private readonly List<Product> products;
        private decimal money;
        private string name;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            
            private set
            {
                Validator.ValidateName(value);

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            
            private set
            {
                Validator.ValidateMoney(value);

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products 
            => this.products;

        public string AddProduct(Product product)
        {
            CheckIfTheMoneyIsEnough(this.Money, product);

            this.Money -= product.Cost;
            this.products.Add(product);

            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(products.Count == 0
                ? $"{this.Name} - Nothing bought "
                : $"{this.Name} - {string.Join(", ", this.GetProductNames())}");

            return result.ToString().TrimEnd();

        }

        private IEnumerable<string> GetProductNames()
        {
            var names = new List<string>();

            foreach (var product in products)
            {
                names.Add(product.Name);
            }

            return names;
        }

        private void CheckIfTheMoneyIsEnough(decimal money, Product product)
        {

            if (money - product.Cost < 0)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
