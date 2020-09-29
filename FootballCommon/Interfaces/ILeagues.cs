using System.Collections.Generic;
using FootballCommon.Entities;

namespace FootballCommon.Interfaces
{
    interface ILeagues
    {
        IEnumerable<League> Leagues { get; set; }
    }
}
