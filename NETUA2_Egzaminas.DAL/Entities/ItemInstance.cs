using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.DAL.Entities
{
    public class ItemInstance
    {
        [Key]
        public int Id { get; set; }

        public string ImgId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool? Stackable { get; set; }
        public int? Count { get; set; }  // Used if the item is stackable
        public int? Level { get; set; }
        public int? Defense { get; set; }
        public int? Attack { get; set; }
        public int? Durability { get; set; }

    }
}
