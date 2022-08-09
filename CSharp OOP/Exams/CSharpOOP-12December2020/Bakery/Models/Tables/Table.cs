using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders ;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => foodOrders;
        
        public IReadOnlyCollection<IDrink> DrinkOrders  => drinkOrders;

        public int TableNumber
        {
            get => tableNumber;
            private set => tableNumber = value;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set => pricePerPerson = value;
        }

        public bool IsReserved { get; private set; }

        public decimal Price => NumberOfPeople * PricePerPerson;
       
        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;

            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
           return foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price) + Price;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;

            IsReserved = false;
        }

        public virtual string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
