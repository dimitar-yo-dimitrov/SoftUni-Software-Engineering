using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer 
    {
        List<Repair> Repairs { get; set; }
    }
}
