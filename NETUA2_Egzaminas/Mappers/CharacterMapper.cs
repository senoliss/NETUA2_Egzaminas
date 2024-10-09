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

            for (int i = 1; i <= 28; i++)
            {
                var dtoSlotProperty = typeof(CharInventory).GetProperty($"Slot{i}");
                var existingSlotProperty = typeof(CharInventory).GetProperty($"Slot{i}");

                if (dtoSlotProperty != null && existingSlotProperty != null)
                {
                    var dtoSlot = dtoSlotProperty.GetValue(dtoInventory) as ItemInstance;
                    var existingSlot = existingSlotProperty.GetValue(existingInventory) as ItemInstance;

                    if (dtoSlot == null)
                    {
                        if (existingSlot != null)
                        {
                            // Instead of setting the slot to null, clear the item instance
                            ClearItemInstance(existingSlot);
                        }
                    }
                    else
                    {
                        if (existingSlot == null)
                        {
                            existingSlotProperty.SetValue(existingInventory, dtoSlot);  // Assign new item if slot is empty
                        }
                        else
                        {
                            // Update the existing item
                            existingSlotProperty.SetValue(existingInventory, UpdateIndividualInventorySlot(dtoSlot, existingSlot));
                        }
                    }
                }
            }

            return existingInventory;

            #region oldcode
            //if (dtoInventory == null) return existingInventory;

            //existingInventory.Slot1 = UpdateIndividualInventorySlot(dtoInventory.Slot1, existingInventory.Slot1);
            //existingInventory.Slot2 = UpdateIndividualInventorySlot(dtoInventory.Slot2, existingInventory.Slot2);
            //existingInventory.Slot3 = UpdateIndividualInventorySlot(dtoInventory.Slot3, existingInventory.Slot3);
            //existingInventory.Slot4 = UpdateIndividualInventorySlot(dtoInventory.Slot4, existingInventory.Slot4);
            //existingInventory.Slot5 = UpdateIndividualInventorySlot(dtoInventory.Slot5, existingInventory.Slot5);
            //existingInventory.Slot6 = UpdateIndividualInventorySlot(dtoInventory.Slot6, existingInventory.Slot6);
            //existingInventory.Slot7 = UpdateIndividualInventorySlot(dtoInventory.Slot7, existingInventory.Slot7);
            //existingInventory.Slot8 = UpdateIndividualInventorySlot(dtoInventory.Slot8, existingInventory.Slot8);
            //existingInventory.Slot9 = UpdateIndividualInventorySlot(dtoInventory.Slot9, existingInventory.Slot9);
            //existingInventory.Slot10 = UpdateIndividualInventorySlot(dtoInventory.Slot10, existingInventory.Slot10);
            //existingInventory.Slot11 = UpdateIndividualInventorySlot(dtoInventory.Slot11, existingInventory.Slot11);
            //existingInventory.Slot12 = UpdateIndividualInventorySlot(dtoInventory.Slot12, existingInventory.Slot12);
            //existingInventory.Slot13 = UpdateIndividualInventorySlot(dtoInventory.Slot13, existingInventory.Slot13);
            //existingInventory.Slot14 = UpdateIndividualInventorySlot(dtoInventory.Slot14, existingInventory.Slot14);
            //existingInventory.Slot15 = UpdateIndividualInventorySlot(dtoInventory.Slot15, existingInventory.Slot15);
            //existingInventory.Slot16 = UpdateIndividualInventorySlot(dtoInventory.Slot16, existingInventory.Slot16);
            //existingInventory.Slot17 = UpdateIndividualInventorySlot(dtoInventory.Slot17, existingInventory.Slot17);
            //existingInventory.Slot18 = UpdateIndividualInventorySlot(dtoInventory.Slot18, existingInventory.Slot18);
            //existingInventory.Slot19 = UpdateIndividualInventorySlot(dtoInventory.Slot19, existingInventory.Slot19);
            //existingInventory.Slot20 = UpdateIndividualInventorySlot(dtoInventory.Slot20, existingInventory.Slot20);
            //existingInventory.Slot21 = UpdateIndividualInventorySlot(dtoInventory.Slot21, existingInventory.Slot21);
            //existingInventory.Slot22 = UpdateIndividualInventorySlot(dtoInventory.Slot22, existingInventory.Slot22);
            //existingInventory.Slot23 = UpdateIndividualInventorySlot(dtoInventory.Slot23, existingInventory.Slot23);
            //existingInventory.Slot24 = UpdateIndividualInventorySlot(dtoInventory.Slot24, existingInventory.Slot24);
            //existingInventory.Slot25 = UpdateIndividualInventorySlot(dtoInventory.Slot25, existingInventory.Slot25);
            //existingInventory.Slot26 = UpdateIndividualInventorySlot(dtoInventory.Slot26, existingInventory.Slot26);
            //existingInventory.Slot27 = UpdateIndividualInventorySlot(dtoInventory.Slot27, existingInventory.Slot27);
            //existingInventory.Slot28 = existingInventory.Slot28 == null || dtoInventory.Slot28 == null ? dtoInventory.Slot28 : UpdateIndividualInventorySlot(dtoInventory.Slot28, existingInventory.Slot28);
            ////existingInventory.Slot28 = UpdateIndividualInventorySlot(dtoInventory.Slot28, existingInventory.Slot28);

            //return existingInventory;
            #endregion
        }

        public ItemInstance UpdateIndividualInventorySlot(ItemInstance dtoItem, ItemInstance existingItem)
        {
            if (dtoItem == null) return existingItem; // If no DTO item, return the existing item as is

            if (existingItem == null) return dtoItem; // If existing item is null, return the new DTO item

            // Update the fields from dtoItem to existingItem
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

            #region oldcode
            //existingItem.ImgId = dtoItem.ImgId;
            //existingItem.Name = dtoItem.Name;
            //existingItem.Type = dtoItem.Type;
            //existingItem.Description = dtoItem.Description;
            //existingItem.Value = dtoItem.Value;
            //existingItem.Stackable = dtoItem.Stackable;
            //existingItem.Count = dtoItem.Count;
            //existingItem.Level = dtoItem.Level;
            //existingItem.Defense = dtoItem.Defense;
            //existingItem.Attack = dtoItem.Attack;
            //existingItem.Durability = dtoItem.Durability;

            //return existingItem;
            #endregion
        }

        public void ClearItemInstance(ItemInstance item)
        {
            item.ImgId = null; // Or set to default/empty values
            item.Name = null;
            item.Type = null;
            item.Description = null;
            item.Value = 0;
            item.Stackable = false;
            item.Count = 0;
            item.Level = 0;
            item.Defense = 0;
            item.Attack = 0;
            item.Durability = 0;
        }
    }
}
