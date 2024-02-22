namespace DnD_Further.Models
{
    public class ClassList
    {
        public int Count { get; set; }
        public List<Class> Class { get; set;}
    }

    public class Class
    {
        public string Name { get; set; }
        public string[] Description { get; set; }
    }
}
