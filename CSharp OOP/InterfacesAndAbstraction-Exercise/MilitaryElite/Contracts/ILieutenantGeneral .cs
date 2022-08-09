using System.Collections.Generic;
using MilitaryElite.Models;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral
    {
        List<Private> Privates { get; set; }
    }
}
