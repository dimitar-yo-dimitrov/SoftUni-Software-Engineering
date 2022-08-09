using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine(mission.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
