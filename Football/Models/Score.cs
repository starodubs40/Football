using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Football.Models
{
    public class Score
    {
        [JsonPropertyName("ft")]
        public List<int> Ft { get; set; }
    }
}
