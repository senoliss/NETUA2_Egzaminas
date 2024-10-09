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
        [JsonIgnore]
        public int? Slot1Id { get; set; }
        public ItemInstance Slot1 { get; set; }

        [ForeignKey("Slot2Id")]
        [JsonIgnore]
        public int? Slot2Id { get; set; }
        public ItemInstance Slot2 { get; set; }

        [ForeignKey("Slot3Id")]
        [JsonIgnore]
        public int? Slot3Id { get; set; }
        public ItemInstance Slot3 { get; set; }

        [ForeignKey("Slot4Id")]
        [JsonIgnore]
        public int? Slot4Id { get; set; }
        public ItemInstance Slot4 { get; set; }

        [ForeignKey("Slot5Id")]
        [JsonIgnore]
        public int? Slot5Id { get; set; }
        public ItemInstance Slot5 { get; set; }

        [ForeignKey("Slot6Id")]
        [JsonIgnore]
        public int? Slot6Id { get; set; }
        public ItemInstance Slot6 { get; set; }

        [ForeignKey("Slot7Id")]
        [JsonIgnore]
        public int? Slot7Id { get; set; }
        public ItemInstance Slot7 { get; set; }

        [ForeignKey("Slot8Id")]
        [JsonIgnore]
        public int? Slot8Id { get; set; }
        public ItemInstance Slot8 { get; set; }

        [ForeignKey("Slot9Id")]
        [JsonIgnore]
        public int? Slot9Id { get; set; }
        public ItemInstance Slot9 { get; set; }

        [ForeignKey("Slot10Id")]
        [JsonIgnore]
        public int? Slot10Id { get; set; }
        public ItemInstance Slot10 { get; set; }

        [ForeignKey("Slot11Id")]
        [JsonIgnore]
        public int? Slot11Id { get; set; }
        public ItemInstance Slot11 { get; set; }

        [ForeignKey("Slot12Id")]
        [JsonIgnore]
        public int? Slot12Id { get; set; }
        public ItemInstance Slot12 { get; set; }

        [ForeignKey("Slot13Id")]
        [JsonIgnore]
        public int? Slot13Id { get; set; }
        public ItemInstance Slot13 { get; set; }

        [ForeignKey("Slot14Id")]
        [JsonIgnore]
        public int? Slot14Id { get; set; }
        public ItemInstance Slot14 { get; set; }

        [ForeignKey("Slot15Id")]
        [JsonIgnore]
        public int? Slot15Id { get; set; }
        public ItemInstance Slot15 { get; set; }

        [ForeignKey("Slot16Id")]
        [JsonIgnore]
        public int? Slot16Id { get; set; }
        public ItemInstance Slot16 { get; set; }

        [ForeignKey("Slot17Id")]
        [JsonIgnore]
        public int? Slot17Id { get; set; }
        public ItemInstance Slot17 { get; set; }

        [ForeignKey("Slot18Id")]
        [JsonIgnore]
        public int? Slot18Id { get; set; }
        public ItemInstance Slot18 { get; set; }

        [ForeignKey("Slot19Id")]
        [JsonIgnore]
        public int? Slot19Id { get; set; }
        public ItemInstance Slot19 { get; set; }

        [ForeignKey("Slot20Id")]
        [JsonIgnore]
        public int? Slot20Id { get; set; }
        public ItemInstance Slot20 { get; set; }

        [ForeignKey("Slot21Id")]
        [JsonIgnore]
        public int? Slot21Id { get; set; }
        public ItemInstance Slot21 { get; set; }

        [ForeignKey("Slot22Id")]
        [JsonIgnore]
        public int? Slot22Id { get; set; }
        public ItemInstance Slot22 { get; set; }

        [ForeignKey("Slot23Id")]
        [JsonIgnore]
        public int? Slot23Id { get; set; }
        public ItemInstance Slot23 { get; set; }

        [ForeignKey("Slot24Id")]
        [JsonIgnore]
        public int? Slot24Id { get; set; }
        public ItemInstance Slot24 { get; set; }

        [ForeignKey("Slot25Id")]
        [JsonIgnore]
        public int? Slot25Id { get; set; }
        public ItemInstance Slot25 { get; set; }

        [ForeignKey("Slot26Id")]
        [JsonIgnore]
        public int? Slot26Id { get; set; }
        public ItemInstance Slot26 { get; set; }

        [ForeignKey("Slot27Id")]
        [JsonIgnore]
        public int? Slot27Id { get; set; }
        public ItemInstance Slot27 { get; set; }

        [ForeignKey("Slot28Id")]
        [JsonIgnore]
        public int? Slot28Id { get; set; }
        public ItemInstance? Slot28 { get; set; }

        // Foreign key for Character
        //[ForeignKey("CharId")]  // Specify that CharId is the FK for Character
        //[JsonIgnore]
        //public int CharId { get; set; }  // Foreign key to Character table
    }

}
