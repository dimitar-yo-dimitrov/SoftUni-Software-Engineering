using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {

        public LieutenantGeneral(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine("Privates:");

            foreach (var @private in this.Privates)
            {
                result.AppendLine($"  {@private}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
