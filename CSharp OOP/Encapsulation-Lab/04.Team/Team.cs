using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;

        private List<Person> reserveTeam;

        private List<Person> firstTeam;

        public Team(string name)
        {
            this.name = name;
            this.reserveTeam = new List<Person>();
            this.firstTeam = new List<Person>();
        }

        public IReadOnlyList<Person> ReserveTeam 
            => reserveTeam.AsReadOnly();

        public IReadOnlyList<Person> FirstTeam 
        => firstTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"First team has {this.FirstTeam.Count} players.");
            sb.AppendLine($"Reserve team has {this.ReserveTeam.Count} players.");

            return sb.ToString().TrimEnd();
        }
    }
}
