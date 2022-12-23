
namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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

        public decimal Cost
        {
            get => this.cost;
            
            private set
            {
                Validator.ValidateMoney(value);

                this.cost = value;
            }
        }
    }
}
