using Newtonsoft.Json;

namespace DnD_Further.Models
{
    public class SpellModel
    {
        [JsonProperty("name")] // Specify the JSON property name
        public string Name { get; set; }

        [JsonProperty("desc")] // Specify the JSON property name
        public string[] Description { get; set; }
    }
}
