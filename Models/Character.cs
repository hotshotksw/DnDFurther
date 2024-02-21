using System.ComponentModel.DataAnnotations;

namespace DnD_Further.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string? UserID { get; set; }
        [Required]
        public string? Name { get; set; }
        
        public int? ClassID { get; set; }
        public Class? Class { get; set; }
        public int? RaceID { get; set; }
        public Race? Race { get; set; }

        [Required, Range(1, 20)]
        public int Strength { get; set; }
        [Required, Range(1, 20)]
        public int Dexterity { get; set; }
        [Required, Range(1, 20)]
        public int Constitution { get; set; }
        [Required, Range(1, 20)]
        public int Intelligence { get; set; }
        [Required, Range(1, 20)]
        public int Wisdom { get; set; }
        [Required, Range(1, 20)]
        public int Charisma { get; set; }

        public Character() { }

        public Character(string name, Race race, Class classes, int str, int dex, int con, int intl, int wis, int cha)
        {
            this.Name = name;
            this.Race = race;
            this.Class = classes;
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Intelligence = intl;
            this.Wisdom = wis;
            this.Charisma = cha;
        }
    }
}