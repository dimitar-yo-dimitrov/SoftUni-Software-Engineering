using System;

namespace MilitaryElite.Models
{
    public class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public string State
        {
            get => state;
            set
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new ArgumentException("Invalid mission state");
                }

                state = value;
            }
        }

        public override string ToString() 
            => $"  Code Name: {this.CodeName} State: {this.State}";
    }
}
