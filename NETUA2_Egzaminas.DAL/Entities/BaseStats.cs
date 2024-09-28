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
	public class BaseStats
	{
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int Health { get; set; }
        public int Magic { get; set; }
        public int Attack { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
        public int Charisma { get; set; }

        // Foreign key properties
        //[ForeignKey("CharId")]  // This tells EF Core that CharId is the FK for this navigation property
        //public int CharId { get; set; }  // Foreign key to Character table

    }
}
