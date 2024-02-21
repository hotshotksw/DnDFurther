using System.ComponentModel.DataAnnotations;

namespace DnD_Further.Models
{
    public class Character
    {
        public enum Races
        {
            Dragonborn,
            Dwarf,
            Elf,
            Gnome,
            Half_Elf,
            Half_Orc,
            Halfing,
            Human,
            Tiefling
        }

        public enum Classes
        {
            BARBARIAN,
            BARD,
            CLERIC,
            DRUID,
            FIGHTER,
            MONK,
            PALADIN,
            RANGER,
            ROUGE,
            SORCERER,
            WARLOCK,
            WIZARD
        }


        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string? UserID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, EnumDataType(typeof(Races))]
        public Races RaceType { get; set; }
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

        public Character(string name, Races race, int str, int dex, int con, int intl, int wis, int cha)
        {
            this.Name = name;
            this.RaceType = race;
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Intelligence = intl;
            this.Wisdom = wis;
            this.Charisma = cha;
        }
    }
}