using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class Character
    {
        [Key]
        public int CharId { get; set; }
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

        // Collections for one-to-many relationships

        public CharSkills Skills { get; set; }         // Practically no need of collection as skills are predetermined in number for all players
        public ICollection<CharQuests> Quests { get; set; }         
        public ICollection<CharAchievement> AchievementsList { get; set; }
        public CharEquipment Equipment { get; set; }
        public CharInventory Inventory { get; set; }
    }
}


// To DO:

// Make equipment entity to have item instanses also
