
namespace FootballCommon.Entities
{
    public class Match
    {
        public string Round { get; set; }
        public string Date { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public Score Score { get; set; }
    }
}
