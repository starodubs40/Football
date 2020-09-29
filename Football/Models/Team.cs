
namespace Football.Models
{
    public class Team
    {
        public string Name { get; set; }
        
        public int Goals { get; set; }

        public int Missed { get; set; }

        public Team (string name , int goals , int missed)
        {
            Name = name; Goals = goals; Missed = missed;  
        }
    }
}
