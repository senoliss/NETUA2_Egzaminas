using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface ICharacterMapper
    {
        public Character CharacterMapping(PostCreateCharacterDTO dto);
        public Character UpdateCharacterMapping(PostCreateCharacterDTO dto, Character existingChar);
        public BaseStats UpdateCharacterBaseStats(BaseStats dtoBaseStats, BaseStats existingBaseStats);
        public Stats UpdateCharacterStats(Stats dtoStats, Stats existingStats);
        public CharSkills UpdateCharacterSkills(CharSkills dtoSkills, CharSkills existingSkills);
        /// <summary>
        /// Updates the skill instance individually since updating CharSkills as a colelction, changes the id of the each skill thus creating duplicate entries in db
        /// </summary>
        /// <param name="dtoSkill"></param>
        /// <param name="existingskill"></param>
        /// <returns></returns>
        public SkillInstance UpdateIndividualSkill(SkillInstance dtoSkill, SkillInstance existingSkill);
        public CharEquipment UpdateCharacterEquipment(CharEquipment dtoEquipment, CharEquipment existingEquipment);
        public CharInventory UpdateCharacterInventory(CharInventory dtoInventory, CharInventory existingInventory);
        /// <summary>
        /// Updates the item instance in inventory individually since updating CharInventory as a colelction, changes the id of the each item thus creating duplicate entries in db
        /// </summary>
        /// <param name="dtoItem"></param>
        /// <param name="existingItem"></param>
        /// <returns></returns>
        public ItemInstance UpdateIndividualInventorySlot(ItemInstance dtoItem, ItemInstance existingItem);
        public void ClearItemInstance(ItemInstance item);

    }
}
