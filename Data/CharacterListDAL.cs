using DnD_Further.Interfaces;
using DnD_Further.Models;
using System;

namespace DnD_Further.Data
{
    public class CharacterListDAL : IDataAccessLayer
    {
        private ApplicationDbContext db;
        public CharacterListDAL(ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddCharacter(Character Character, string userID)
        {
            Character.UserID = userID;
            db.Characters.Add(Character);
            db.SaveChanges();
        }

        public void RemoveCharacter(int? id)
        {
            Character? foundCharacter = GetCharacter(id);
            if (foundCharacter != null)
            {
                db.Characters.Remove(foundCharacter);
                db.SaveChanges();
            }
        }

        public Character? GetCharacter(int? id)
        {
            Character? foundCharacter = db.Characters.Where(g => g.Id == id).FirstOrDefault();
            return foundCharacter;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return db.Characters;
        }

        public void UpdateCharacter(Character Character, string userID)
        {
			Character.UserID = userID;
			db.Characters.Update(Character);
            db.SaveChanges();
        }

        public IEnumerable<Character> FilterCharacters(string? name)
        {
            if(name == null)
            {
                name = "";
            }
            
            if (name == "")
            {
                return GetCharacters();
            }

            IEnumerable<Character> lstCharactersByName = GetCharacters().Where
                (c => (!string.IsNullOrEmpty(c.Name) &&
                c.Name.ToLower().Contains(name.ToLower()))).ToList();

            return lstCharactersByName;
        }

		public IEnumerable<Character>? GetCharactersByUser(string userID)
		{
			return db.Characters.Where(x => x.UserID == userID);
		}

		public void CheckEditable(string? userID)
		{
			foreach (Character c in db.Characters)
            {
                if (c.UserID == userID)
                {
                    c.editable = true;
                }
                else
                {
                    c.editable = false;
                }
            }
		}
	}
}
