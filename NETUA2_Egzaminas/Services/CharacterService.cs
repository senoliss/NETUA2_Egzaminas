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
			var character = await _context.Characters
                .Include(c => c.BaseStats)
                .Include(c => c.Stats)
	            .Include(c => c.Quests)
                .Include(c => c.AchievementsList)
                .Include(c => c.Equipment)
                //.Include(c => c.Inventory)
                .FirstOrDefaultAsync(c => c.CharId == id);

			if (character != null)
			{
				character.Skills = await GetCharacterSkillsByIdAsync(character.CharId);
                character.Inventory = await GetCharacterInventoryByIdAsync(character.CharId);
			}

			return character;
		}
        public async Task<Character?> GetCharacterByEmailAsync(string mail)
        {
			var character = await _context.Characters
                .Include(c => c.BaseStats)
                .Include(c => c.Stats)
	            .Include(c => c.Quests)
                .Include(c => c.AchievementsList)
                .Include(c => c.Equipment)
                //.Include(c => c.Inventory)
                .FirstOrDefaultAsync(c => c.Email == mail);

			if (character != null)
			{
				character.Skills = await GetCharacterSkillsByIdAsync(character.CharId);
                character.Inventory = await GetCharacterInventoryByIdAsync(character.CharId);
			}

			return character;
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
            #region Gets Character all 28 slots included
            var character = await _context.Characters
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot1)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot2)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot3)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot4)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot5)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot6)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot7)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot8)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot9)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot10)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot11)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot12)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot13)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot14)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot15)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot16)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot17)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot18)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot19)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot20)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot21)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot22)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot23)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot24)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot25)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot26)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot27)
                            .Include(c => c.Inventory)
                            .ThenInclude(c => c.Slot28)
                            .FirstOrDefaultAsync(c => c.CharId == id);
            #endregion

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


        public async Task<CharSkills> GetCharacterSkillsByIdAsync(int id)
        {
            var character = await _context.Characters
								   .Include(c => c.Skills).ThenInclude(s => s.Woodcutting)
                                   .Include(c => c.Skills).ThenInclude(s => s.Mining)
                                   .Include(c => c.Skills).ThenInclude(s => s.Fishing)
                                   .Include(c => c.Skills).ThenInclude(s => s.Cooking)
                                   .Include(c => c.Skills).ThenInclude(s => s.Crafting)
                                   .Include(c => c.Skills).ThenInclude(s => s.Smithing)
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
            var character = await GetCharacterAsync(id); //_context.Characters.FindAsync(id);


			if (character == null)
                return false;


            // Can't graspo how to setup cascade delete on these fucked up relations between tables
            _context.CharInventory.Remove(character.Inventory);
            _context.CharSkills.Remove(character.Skills);
            _context.BaseStats.Remove(character.BaseStats);
            _context.Stats.Remove(character.Stats);
            _context.CharEquipment.Remove(character.Equipment);

			#region deleteCharSkills
			_context.SkillInstances.Remove(character.Skills.Woodcutting);
            _context.SkillInstances.Remove(character.Skills.Mining);
            _context.SkillInstances.Remove(character.Skills.Fishing);
            _context.SkillInstances.Remove(character.Skills.Cooking);
            _context.SkillInstances.Remove(character.Skills.Crafting);
            _context.SkillInstances.Remove(character.Skills.Smithing);
            #endregion

            #region deleteCharInventory
            _context.ItemInstances.Remove(character.Inventory.Slot1);
            _context.ItemInstances.Remove(character.Inventory.Slot2);
            _context.ItemInstances.Remove(character.Inventory.Slot3);
            _context.ItemInstances.Remove(character.Inventory.Slot4);
            _context.ItemInstances.Remove(character.Inventory.Slot5);
            _context.ItemInstances.Remove(character.Inventory.Slot6);
            _context.ItemInstances.Remove(character.Inventory.Slot7);
            _context.ItemInstances.Remove(character.Inventory.Slot8);
            _context.ItemInstances.Remove(character.Inventory.Slot9);
            _context.ItemInstances.Remove(character.Inventory.Slot10);
            _context.ItemInstances.Remove(character.Inventory.Slot11);
            _context.ItemInstances.Remove(character.Inventory.Slot12);
            _context.ItemInstances.Remove(character.Inventory.Slot13);
            _context.ItemInstances.Remove(character.Inventory.Slot14);
            _context.ItemInstances.Remove(character.Inventory.Slot15);
            _context.ItemInstances.Remove(character.Inventory.Slot16);
            _context.ItemInstances.Remove(character.Inventory.Slot17);
            _context.ItemInstances.Remove(character.Inventory.Slot18);
            _context.ItemInstances.Remove(character.Inventory.Slot19);
            _context.ItemInstances.Remove(character.Inventory.Slot20);
            _context.ItemInstances.Remove(character.Inventory.Slot21);
            _context.ItemInstances.Remove(character.Inventory.Slot22);
            _context.ItemInstances.Remove(character.Inventory.Slot23);
            _context.ItemInstances.Remove(character.Inventory.Slot24);
            _context.ItemInstances.Remove(character.Inventory.Slot25);
            _context.ItemInstances.Remove(character.Inventory.Slot26);
            _context.ItemInstances.Remove(character.Inventory.Slot27);
            _context.ItemInstances.Remove(character.Inventory.Slot28);
            #endregion

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Character?> UpdateCharacterAsync(int id, PostCreateCharacterDTO dto)
        {
            var existingCharacter = await GetCharacterAsync(id);

            if (existingCharacter == null)
                return null;

            existingCharacter = _mapper.UpdateCharacterMapping(dto, existingCharacter);

            _context.Characters.Update(existingCharacter);
            await _context.SaveChangesAsync();

            return existingCharacter;
        }
    }
}
