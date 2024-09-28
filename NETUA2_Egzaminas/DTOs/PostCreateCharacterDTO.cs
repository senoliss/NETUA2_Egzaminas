using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.DTOs
{
    public class PostCreateCharacterDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string Class { get; set; }
        public bool IsAdmin { get; set; }
        public int Money { get; set; }

        // Navigational properties
        public BaseStats BaseStats { get; set; }
        public Stats Stats { get; set; }
        public List<CharSkills> Skills { get; set; }
        public List<CharQuests> Quests { get; set; }
        public List<CharAchievement> AchievementsList { get; set; }
        public CharEquipment Equipment { get; set; }
        public CharInventory Inventory { get; set; }
    }
}
