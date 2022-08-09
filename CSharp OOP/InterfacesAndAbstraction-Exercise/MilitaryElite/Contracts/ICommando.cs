using System.Collections.Generic;
using MilitaryElite.Models;

namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        List<Mission> Missions { get; }
    }
}
