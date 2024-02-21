using System.ComponentModel.DataAnnotations;

namespace DnD_Further.Models
{
    public class Class
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
    }
}
