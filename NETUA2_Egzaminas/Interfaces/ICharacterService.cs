using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    /// <summary>
    /// Service to handle character-related operations.
    /// </summary>
    public interface ICharacterService
    {
        Task<Character> CreateCharacterAsync(PostCreateCharacterDTO dto);
        Task<Character?> GetCharacterAsync(int id);
        Task<Character?> GetCharacterByEmailAsync(string mail);
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<CharInventory> GetCharacterInventoryByIdAsync(int id);
        Task<CharEquipment> GetCharacterEquipmentByIdAsync(int id);
        Task<CharSkills> GetCharacterSkillsByIdAsync(int id);
        Task<IEnumerable<CharQuests>> GetCharacterQuestsByIdAsync(int id);
        Task<IEnumerable<CharAchievement>> GetCharacterAchievementsByIdAsync(int id);
        Task<BaseStats> GetCharacterBaseStatsByIdAsync(int id);
        Task<Stats> GetCharacterStatsByIdAsync(int id);
        Task<bool> DeleteCharacterAsync(int id);
        Task<Character?> UpdateCharacterAsync(int id, PostCreateCharacterDTO dto);
    }
}
