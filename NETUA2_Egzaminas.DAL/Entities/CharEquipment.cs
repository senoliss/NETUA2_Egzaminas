using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class CharEquipment
	{
        [Key]
        public int Id { get; set; }
		public string? Helmet { get; set; }
		public string? Armor { get; set; }
		public string? Weapon { get; set; }
		public string? Shield { get; set; }
		public string? Legs { get; set; }
		public string? Gloves { get; set; }
		public string? Boots { get; set; }
		public string? Amulet { get; set; }
		public string? RingLeft { get; set; }
		public string? RingRight { get; set; }

		// Foreign key properties
		public int CharId { get; set; }  // Foreign key to Character table
	}
}
