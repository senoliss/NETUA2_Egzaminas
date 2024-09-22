using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class CharInventory
	{
        [Key]
        public int Id { get; set; }
        public int Health { get; set; }
        public int Magic { get; set; }
        public int Attack { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
        public int Charisma { get; set; }

		// Foreign key properties
		public int CharId { get; set; }  // Foreign key to Character table
	}
}
