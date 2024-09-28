using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
    public class CharacterMapper : ICharacterMapper
    {
        public Character CharacterMapping(PostCreateCharacterDTO dto)
        {
            var character = new Character
            {
                Email = dto.Email,
                Name = dto.Name,
                Level = dto.Level,
                Experience = dto.Experience,
                Class = dto.Class,
                IsAdmin = dto.IsAdmin,
                Money = dto.Money,
                BaseStats = dto.BaseStats,
                Stats = dto.Stats,
                Skills = dto.Skills,
                Quests = dto.Quests,
                AchievementsList = dto.AchievementsList,
                Equipment = dto.Equipment,
                Inventory = dto.Inventory
            };

            return character;
        }

        public Character UpdateCharacterMapping(PostCreateCharacterDTO dto, Character existingCharacter)
        {
            // Manual mapping from DTO to existing entity
            existingCharacter.Email = dto.Email;
            existingCharacter.Name = dto.Name;
            existingCharacter.Level = dto.Level;
            existingCharacter.Experience = dto.Experience;
            existingCharacter.Class = dto.Class;
            existingCharacter.IsAdmin = dto.IsAdmin;
            existingCharacter.Money = dto.Money;
            existingCharacter.BaseStats = dto.BaseStats;
            existingCharacter.Stats = dto.Stats;
            existingCharacter.Skills = dto.Skills;
            existingCharacter.Quests = dto.Quests;
            existingCharacter.AchievementsList = dto.AchievementsList;
            existingCharacter.Equipment = dto.Equipment;
            existingCharacter.Inventory = dto.Inventory;

            return existingCharacter;
        }
    }
}
