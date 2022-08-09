using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidNameOfException);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                
                return (int)Math.Round(players.Average(x => x.Stats));
            } 
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var playerToRemove = players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new ArgumentException
                    ($"Player {name} is not in {this.Name} team.");
            }

            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
