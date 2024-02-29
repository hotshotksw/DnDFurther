using DnD_Further.Models;

namespace DnD_Further.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Character> GetCharacters();
        void AddCharacter(Character character, string userID);
        void RemoveCharacter(int? id);
        Character? GetCharacter(int? id);
        void UpdateCharacter(Character character, string userID);
        void CheckEditable(string userID);
        IEnumerable<Character>? GetCharactersByUser(string userID);
        IEnumerable<Character> FilterCharacters(string? name);
    }
}
