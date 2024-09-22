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
        public CharSkills Skills { get; set; }
        public CharQuests Quests { get; set; }
        public CharAcheivements Achievements { get; set; }
        public CharEquipment Equipment { get; set; }
        public CharInventory Inventory { get; set; }
    }
}
