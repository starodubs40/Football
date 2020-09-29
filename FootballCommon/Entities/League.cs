using System.Collections.Generic;

namespace FootballCommon.Entities
{
    public class League
    {
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


