using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;
using static System.Reflection.Metadata.BlobBuilder;

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
            existingCharacter.BaseStats = UpdateCharacterBaseStats(dto.BaseStats, existingCharacter.BaseStats);
            existingCharacter.Stats = UpdateCharacterStats(dto.Stats, existingCharacter.Stats);
            existingCharacter.Skills = UpdateCharacterSkills(dto.Skills, existingCharacter.Skills);
            existingCharacter.Quests = dto.Quests;
            existingCharacter.AchievementsList = dto.AchievementsList;
            existingCharacter.Equipment = UpdateCharacterEquipment(dto.Equipment, existingCharacter.Equipment);
            existingCharacter.Inventory = UpdateCharacterInventory(dto.Inventory, existingCharacter.Inventory);

            return existingCharacter;
        }
        public BaseStats UpdateCharacterBaseStats(BaseStats dtoBaseStats, BaseStats existingBaseStats)
        {
            if (dtoBaseStats == null) return existingBaseStats;

            existingBaseStats.Health = dtoBaseStats.Health;
            existingBaseStats.Magic = dtoBaseStats.Magic;
            existingBaseStats.Attack = dtoBaseStats.Attack;
            existingBaseStats.Strength = dtoBaseStats.Strength;
            existingBaseStats.Agility = dtoBaseStats.Agility;
            existingBaseStats.Defense = dtoBaseStats.Defense;
            existingBaseStats.Charisma = dtoBaseStats.Charisma;

            return existingBaseStats;
        }
        public Stats UpdateCharacterStats(Stats dtoStats, Stats existingStats)
        {
            if (dtoStats == null) return existingStats;

            existingStats.Health = dtoStats.Health;
            existingStats.Magic = dtoStats.Magic;
            existingStats.Attack = dtoStats.Attack;
            existingStats.Strength = dtoStats.Strength;
            existingStats.Agility = dtoStats.Agility;
            existingStats.Defense = dtoStats.Defense;
            existingStats.Charisma = dtoStats.Charisma;

            return existingStats;
        }
        public CharSkills UpdateCharacterSkills(CharSkills dtoSkills, CharSkills existingSkills)
        {
            if (dtoSkills == null) return existingSkills;

            existingSkills.Woodcutting = UpdateIndividualSkill(dtoSkills.Woodcutting, existingSkills.Woodcutting);

            existingSkills.Mining = UpdateIndividualSkill(dtoSkills.Mining, existingSkills.Mining);

            existingSkills.Fishing = UpdateIndividualSkill(dtoSkills.Fishing, existingSkills.Fishing);

            existingSkills.Cooking = UpdateIndividualSkill(dtoSkills.Cooking, existingSkills.Cooking);

            existingSkills.Crafting = UpdateIndividualSkill(dtoSkills.Crafting, existingSkills.Crafting);

            existingSkills.Smithing = UpdateIndividualSkill(dtoSkills.Smithing, existingSkills.Smithing);

            return existingSkills;
        }
        public SkillInstance UpdateIndividualSkill(SkillInstance dtoSkill, SkillInstance existingSkill)
        {
            existingSkill.Level = dtoSkill.Level;
            existingSkill.Xp = dtoSkill.Xp;
            existingSkill.XpCap = dtoSkill.XpCap;

            return existingSkill;
        }
        public CharEquipment UpdateCharacterEquipment(CharEquipment dtoEquipment, CharEquipment existingEquipment)
        {
            if (dtoEquipment == null) return existingEquipment;

            existingEquipment.Helmet = dtoEquipment.Helmet;
            existingEquipment.Armor = dtoEquipment.Armor;
            existingEquipment.Weapon = dtoEquipment.Weapon;
            existingEquipment.Shield = dtoEquipment.Shield;
            existingEquipment.Legs = dtoEquipment.Legs;
            existingEquipment.Gloves = dtoEquipment.Gloves;
            existingEquipment.Boots = dtoEquipment.Boots;
            existingEquipment.Amulet = dtoEquipment.Amulet;
            existingEquipment.RingLeft = dtoEquipment.RingLeft;
            existingEquipment.RingRight = dtoEquipment.RingRight;

            return existingEquipment;
        }
        public CharInventory UpdateCharacterInventory(CharInventory dtoInventory, CharInventory existingInventory)
        {
            if (dtoInventory == null) return existingInventory;

            existingInventory.Slot1 = UpdateIndividualInventorySlot(dtoInventory.Slot1, existingInventory.Slot1);
            existingInventory.Slot2 = UpdateIndividualInventorySlot(dtoInventory.Slot2, existingInventory.Slot2);
            existingInventory.Slot3 = UpdateIndividualInventorySlot(dtoInventory.Slot3, existingInventory.Slot3);

            return existingInventory;
        }
        public ItemInstance UpdateIndividualInventorySlot(ItemInstance dtoItem, ItemInstance existingItem)
        {
            existingItem.ImgId = dtoItem.ImgId;
            existingItem.Name = dtoItem.Name;
            existingItem.Type = dtoItem.Type;
            existingItem.Description = dtoItem.Description;
            existingItem.Value = dtoItem.Value;
            existingItem.Stackable = dtoItem.Stackable;
            existingItem.Count = dtoItem.Count;
            existingItem.Level = dtoItem.Level;
            existingItem.Defense = dtoItem.Defense;
            existingItem.Attack = dtoItem.Attack;
            existingItem.Durability = dtoItem.Durability;

            return existingItem;
        }
    }
}
