using Newtonsoft.Json;

namespace DnD_Further.Models
{
    public class SpellModel
    {
        [JsonProperty("name")] // Specify the JSON property name
        public string Name { get; set; }

        [JsonProperty("desc")] // Specify the JSON property name
        public string[] Description { get; set; }
        [JsonProperty("url")] // Specify the JSON property name
        public string URL { get; set; }
    }

    public class SpellList
    {
        public int Count { get; set; }
        public List<SpellModel> Results { get; set; }
    }
}
