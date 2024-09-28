using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETUA2_Egzaminas.DAL.Entities
{
    public class CharInventory
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        // Inventory slots that reference ItemInstance (no cascade delete)
        [ForeignKey("Slot1Id")]
        public int? Slot1Id { get; set; }
        public ItemInstance Slot1 { get; set; }

        [ForeignKey("Slot2Id")]
        public int? Slot2Id { get; set; }
        public ItemInstance Slot2 { get; set; }

        [ForeignKey("Slot3Id")]
        public int? Slot3Id { get; set; }
        public ItemInstance Slot3 { get; set; }

        // Foreign key for Character
        //[ForeignKey("CharId")]  // Specify that CharId is the FK for Character
        //[JsonIgnore]
        //public int CharId { get; set; }  // Foreign key to Character table
    }
}
