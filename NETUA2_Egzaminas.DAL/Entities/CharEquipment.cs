using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class CharEquipment
	{
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        // Inventory slots that reference ItemInstance (no cascade delete)
        [ForeignKey("HelmetId")]
        [JsonIgnore]
        public int? HelmetId { get; set; }
		public ItemInstance Helmet { get; set; }

        [ForeignKey("ArmorId")]
        [JsonIgnore]
        public int? ArmorId { get; set; }
		public ItemInstance Armor { get; set; }

        [ForeignKey("WeaponId")]
        [JsonIgnore]
        public int? WeaponId { get; set; }
		public ItemInstance Weapon { get; set; }

        [ForeignKey("ShieldId")]
        [JsonIgnore]
        public int? ShieldId { get; set; }
		public ItemInstance Shield { get; set; }

        [ForeignKey("LegsId")]
        [JsonIgnore]
        public int? LegsId { get; set; }
		public ItemInstance Legs { get; set; }

        [ForeignKey("GlovesId")]
        [JsonIgnore]
        public int? GlovesId { get; set; }
		public ItemInstance Gloves { get; set; }

        [ForeignKey("BootsId")]
        [JsonIgnore]
        public int? BootsId { get; set; }
		public ItemInstance Boots { get; set; }

        [ForeignKey("AmuletId")]
        [JsonIgnore]
        public int? AmuletId { get; set; }
		public ItemInstance Amulet { get; set; }

        [ForeignKey("RingLeftId")]
        [JsonIgnore]
        public int? RingLeftId { get; set; }
		public ItemInstance RingLeft { get; set; }

        [ForeignKey("RingRightId")]
        [JsonIgnore]
        public int? RingRightId { get; set; }
		public ItemInstance RingRight { get; set; }

        // Foreign key for Character
        //[ForeignKey("CharId")]  // Specify that CharId is the FK for Character
        //[JsonIgnore]
        //public int CharId { get; set; }  // Foreign key to Character table
    }
}
