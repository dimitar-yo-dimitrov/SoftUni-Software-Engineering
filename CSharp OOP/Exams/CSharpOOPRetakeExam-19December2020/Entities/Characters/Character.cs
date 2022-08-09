using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(
            string name,
            double health,
            double armor,
            double abilityPoints,
            Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
            set
            {
                if (value <= BaseArmor && value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; } = 40;

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor >= hitPoints)
            {
                Armor -= hitPoints;
            }

            else if (Armor < hitPoints)
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;

                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            string status = null;

            if (IsAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }

            StringBuilder sb = new StringBuilder();

            string value =
                $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";

            sb.AppendLine(value);

            return sb.ToString().TrimEnd();
        }
    }
}