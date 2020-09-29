using Football.Interfaces;
using Football.Services;
using Football.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Football.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagues Leagues;
        
        public LeagueController(ILeagues leagues)
        {
            Leagues = leagues;
        }

        public ViewResult List()
        {
            var league = new ServiceLeagues().GetLeague;
            return View(league);
        }

        public ViewResult BestTeams()
        {
            Team bestAttakingTeam1 = new ServiceLeagues().GetBestAttackingTeam("en.1.json");
            Team bestAttakingTeam2 = new ServiceLeagues().GetBestAttackingTeam("en.2.json");
            Team bestAttakingTeam3 = new ServiceLeagues().GetBestAttackingTeam("en.3.json");

            ViewBag.BestAttakingTeam1 = bestAttakingTeam1;
            ViewBag.BestAttakingTeam2 = bestAttakingTeam2;
            ViewBag.BestAttakingTeam3 = bestAttakingTeam3;
            //

            Team bestProtectingTeam1 = new ServiceLeagues().GetBestProtectingTeam("en.1.json");
            Team bestProtectingTeam2 = new ServiceLeagues().GetBestProtectingTeam("en.2.json");
            Team bestProtectingTeam3 = new ServiceLeagues().GetBestProtectingTeam("en.3.json");

            ViewBag.BestProtectingTeam1 = bestProtectingTeam1;
            ViewBag.BestProtectingTeam2 = bestProtectingTeam2;
            ViewBag.BestProtectingTeam3 = bestProtectingTeam3;

            return View();
        }
    }
}
