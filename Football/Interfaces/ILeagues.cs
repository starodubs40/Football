using System.Collections.Generic;
using Football.Models;

namespace Football.Interfaces
{
    public interface ILeagues
    {
        League GetLeague { get; }

        //Найкращу атакуючу команду (яка забила найбільшу кількість голів в своїй лізі)
        Team GetBestAttackingTeam(string path);

        Team GetBestProtectingTeam(string path);
    }
}
