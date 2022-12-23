﻿using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
       
        public string Id { get; set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
