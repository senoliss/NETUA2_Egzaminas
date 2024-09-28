using Microsoft.EntityFrameworkCore;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;

namespace NETUA2_Egzaminas.API.Services
{
    /// <summary>
    /// Implements character service for managing character-related operations.
    /// </summary>
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;
        private readonly ICharacterMapper _mapper;

        public CharacterService(AppDbContext context, ICharacterMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        // Manually map PostCreateCharacterDTO to Character
        public async Task<Character> CreateCharacterAsync(PostCreateCharacterDTO dto)
        {
            // Manual mapping from DTO to Entity
            var character = _mapper.CharacterMapping(dto);

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<Character?> GetCharacterAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.BaseStats)
                .Include(c => c.Stats)
                .Include(c => c.Skills)
                .Include(c => c.Quests)
                .Include(c => c.AchievementsList)
                .Include(c => c.Equipment)
                .Include(c => c.Inventory)
                .FirstOrDefaultAsync(c => c.CharId == id);
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters
                .Include(c => c.BaseStats)
                .Include(c => c.Stats)
                .Include(c => c.Skills)
                .Include(c => c.Quests)
                .Include(c => c.AchievementsList)
                .Include(c => c.Equipment)
                .Include(c => c.Inventory)
                .ToListAsync();
        }

        public async Task<CharInventory> GetCharacterInventoryByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(c => c.Inventory)
                                   .FirstOrDefaultAsync(c => c.CharId == id);
            if (character == null)
                return null;
            
            return character.Inventory;
        }

        public async Task<CharEquipment> GetCharacterEquipmentByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(c => c.Equipment)
                                   .FirstOrDefaultAsync(c => c.CharId == id);
            if (character == null)
                return null;
            
            return character.Equipment;
        }


        public async Task<IEnumerable<CharSkills>> GetCharacterSkillsByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(s => s.Skills)
                                   .FirstOrDefaultAsync(s => s.CharId == id);
            if (character == null)
                return null;

            return character.Skills;
        }
        public async Task<IEnumerable<CharQuests>> GetCharacterQuestsByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(q => q.Quests)
                                   .FirstOrDefaultAsync(q => q.CharId == id);
            if (character == null)
                return null;

            return character.Quests;
        }
        public async Task<IEnumerable<CharAchievement>> GetCharacterAchievementsByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(a => a.AchievementsList)
                                   .FirstOrDefaultAsync(a => a.CharId == id);
            if (character == null)
                return null;

            return character.AchievementsList;
        }
        public async Task<BaseStats> GetCharacterBaseStatsByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(bs => bs.BaseStats)
                                   .FirstOrDefaultAsync(bs => bs.CharId == id);
            if (character == null)
                return null;

            return character.BaseStats;
        }
        public async Task<Stats> GetCharacterStatsByIdAsync(int id)
        {
            var character = await _context.Characters
                                   .Include(s => s.Stats)
                                   .FirstOrDefaultAsync(s => s.CharId == id);
            if (character == null)
                return null;

            return character.Stats;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
                return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Character?> UpdateCharacterAsync(int id, PostCreateCharacterDTO dto)
        {
            var existingCharacter = await _context.Characters.FindAsync(id);

            if (existingCharacter == null)
                return null;

            existingCharacter = _mapper.UpdateCharacterMapping(dto, existingCharacter);

            _context.Characters.Update(existingCharacter);
            await _context.SaveChangesAsync();

            return existingCharacter;
        }
    }
}
