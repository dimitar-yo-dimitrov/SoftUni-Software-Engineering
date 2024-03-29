﻿using FoodShortage.Contracts;
using FoodShortage.Enums;

namespace FoodShortage.Models
{
    public class Citizen : Person, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, age, birthdate)
        {
            this.Id = id;
        }
        
        public string Id { get; private set; }

        public override void BuyFood()
        {
            int increasesFood = (int)IncreasesFood.increasesFoodCitizen;

            this.Food += increasesFood;
        }
    }
}
