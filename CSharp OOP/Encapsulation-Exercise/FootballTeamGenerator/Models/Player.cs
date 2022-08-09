using System;
using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player
            (string name, 
                int endurance, 
                int sprint, 
                int dribble, 
                int passing, 
                int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            set
            {
                CheckName(value);

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            
            private set
            {
                CheckRange(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            
            private set
            {
                CheckRange(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            
            private set
            {
                CheckRange(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;

            private set
            {
                CheckRange(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;

            private set
            {
                CheckRange(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double Stats 
            => (this.Endurance + 
               this.Sprint + 
               this.Dribble + 
               this.Passing + 
               this.Shooting) / 5.0;

        private void CheckName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidNameOfException);
            }
        }

        private void CheckRange(double value, string statName)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidRangeOfException,
                        statName));
            }
        }
    }
}
