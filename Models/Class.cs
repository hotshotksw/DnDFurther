using Newtonsoft.Json;

namespace DnD_Further.Models
{
    public class Class
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("")]
        public string[] Description { get; set; }
        [JsonProperty("hit_die")]
        public string hitDie { get; set; }
    }

    public class ClassList
    {
        public int Count { get; set; }
        public List<Class> Class { get; set; }
    }
}
