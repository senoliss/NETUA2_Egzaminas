using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ImgId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool? Stackable { get; set; }
        public int? Count { get; set; }
        public int? Level { get; set; }
        public int? Defense { get; set; }
        public int? Attack { get; set; }
        public int? Durability { get; set; }
    }
}
