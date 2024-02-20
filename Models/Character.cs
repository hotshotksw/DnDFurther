﻿using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string? Name { get; set; }
        [Required]
        public Races Race { get; set; }

        public Character() { }

        public Character(string name, Races race)
        {
            this.Name = name;
            this.Race = race;
        }
    }
}