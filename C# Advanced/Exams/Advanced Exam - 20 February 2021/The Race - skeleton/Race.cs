using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public List<Racer> Data { get; set; }
        public int Count => Data.Count;
        public string Name { get; set; }
        public int Capacity { get; set; } //the maximum allowed number of racers

        public void Add(Racer racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racerToRemove = Data.FirstOrDefault(x => x.Name == name);

            if (racerToRemove == null)
            {
                return false;
            }

            Data.Remove(racerToRemove);
            return true;
        }

        public Racer GetOldestRacer() => Data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name) => Data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer() => Data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
