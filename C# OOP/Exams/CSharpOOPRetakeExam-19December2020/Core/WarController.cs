using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> party;
        private readonly Stack<Item> itemPool;

        public WarController()
        {
            party = new List<Character>();
            itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            switch (characterType)
            {
                case "Warrior":
                    {
                        Character character = new Warrior(name);

                        party.Add(character);
                        break;
                    }
                case "Priest":
                    {
                        Character character = new Priest(name);

                        party.Add(character);
                        break;
                    }
                default:
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidCharacterType, characterType));
            }

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            itemPool.Push(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item lastItem = itemPool.Pop();
            character.Bag.AddItem(lastItem);

            return string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }


            Item currentItem = character.Bag.GetItem(itemName);
            currentItem.AffectCharacter(character);

            return string.Format(SuccessMessages.UsedItem, characterName, currentItem.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character character in party
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var characterAttacker = party.FirstOrDefault(c => c.Name == attackerName);

            if (characterAttacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            var characterReceiver = party.FirstOrDefault(c => c.Name == receiverName);

            if (characterReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!(characterAttacker is IAttacker attacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            if (characterReceiver.Health == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");
            }

            attacker.Attack(characterReceiver);

            StringBuilder sb = new StringBuilder();

            string successfullyAttack = string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                characterAttacker.AbilityPoints, receiverName, characterReceiver.Health, characterReceiver.BaseHealth, characterReceiver.Armor,
                characterReceiver.BaseArmor);

            sb.AppendLine(successfullyAttack);

            if (!characterReceiver.IsAlive)
            {
                sb.AppendLine($"{string.Format(SuccessMessages.AttackKillsCharacter, receiverName)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healerCharacter = party.FirstOrDefault(c => c.Name == healerName);

            if (healerCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            var receiverCharacter = party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (receiverCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (!(healerCharacter is IHealer healer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.Heal(receiverCharacter);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(SuccessMessages.HealCharacter,
                healerName, healingReceiverName, healerCharacter.AbilityPoints,
                healingReceiverName, receiverCharacter.Health);

            return sb.ToString().TrimEnd();
        }
    }
}
