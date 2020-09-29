using Football.Interfaces;
using Football.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;

namespace Football.Services
{
    public class ServiceLeagues : ILeagues
    {
        public ServiceLeagues()
        {
        }

        // @"C:\Users\Admin\Desktop\Football\Football\Football\en.1.json" 
        public League GetLeague => DeserializeLeague("en.1.json").Result;

        public Team GetBestAttackingTeam(string path)
        { 
             return BestAttackingTeam(path);
        }

        public Team GetBestProtectingTeam(string path)
        {
            return BestProtectingTeam(path);
        }

        public Team BestProtectingTeam(string path)
        {
            League league = DeserializeLeague(path).Result;

            Dictionary<string, int> teamGoals = new Dictionary<string, int>();
            Dictionary<string, int> teamMissed = new Dictionary<string, int>();

            foreach (var match in league.Matches)
            {
                if (teamGoals.ContainsKey(match.Team1))
                {
                    teamGoals[match.Team1] += match.Score.Ft[0];
                    teamMissed[match.Team1] += match.Score.Ft[1];
                }
                else
                {
                    teamGoals.Add(match.Team1, match.Score.Ft[0]);
                    teamMissed.Add(match.Team1, match.Score.Ft[1]);
                }

                if (teamGoals.ContainsKey(match.Team2))
                {
                    teamGoals[match.Team2] += match.Score.Ft[1];
                    teamMissed[match.Team2] += match.Score.Ft[0];
                }
                else
                {
                    teamGoals.Add(match.Team2, match.Score.Ft[1]);
                    teamMissed.Add(match.Team2, match.Score.Ft[0]);
                }
            }

            string team = teamMissed.OrderBy(x => x.Value).FirstOrDefault().Key;

            return new Team(team, teamGoals[team], teamMissed[team]);
        }

        public Team BestAttackingTeam(string path)
        {
            League league = DeserializeLeague(path).Result;

            Dictionary<string , int > teamGoals = new Dictionary<string , int >();
            Dictionary<string, int> teamMissed = new Dictionary<string, int>();

            foreach (var match in league.Matches)
            {
                if (teamGoals.ContainsKey(match.Team1))
                {
                    teamGoals[match.Team1] += match.Score.Ft[0];
                    teamMissed[match.Team1] += match.Score.Ft[1];
                }
                else
                {
                    teamGoals.Add(match.Team1, match.Score.Ft[0]);
                    teamMissed.Add(match.Team1, match.Score.Ft[1]);
                }

                if (teamGoals.ContainsKey(match.Team2))
                {
                    teamGoals[match.Team2] += match.Score.Ft[1];
                    teamMissed[match.Team2] += match.Score.Ft[0];
                }
                else
                {
                    teamGoals.Add(match.Team2, match.Score.Ft[1]);
                    teamMissed.Add(match.Team2, match.Score.Ft[0]);
                }
            }

            string team = teamGoals.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            
            return new Team(team , teamGoals[team] , teamMissed[team] );
        }
      
        private async Task<League> DeserializeLeague(string path)
        {
            League deserializedLeague = null;

            using  (var stream = new FileStream(path , FileMode.Open))
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                deserializedLeague = await JsonSerializer.DeserializeAsync<League>(stream, options);
            }

            return deserializedLeague;
        }
    }


}

