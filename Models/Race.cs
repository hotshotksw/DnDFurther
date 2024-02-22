using Newtonsoft.Json;

namespace DnD_Further.Models
{
    public class Race
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("speed")]
        public string Speed { get; set; }
    }

    public class RaceList
    {
        public int Count { get; set; }
        public List<Race> Races { get; set; }
    }
}
