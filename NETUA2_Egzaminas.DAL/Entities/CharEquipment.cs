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
		public int Helmet { get; set; }
		public int Armor { get; set; }
		public int Weapon { get; set; }
		public int Shield { get; set; }
		public int Legs { get; set; }
		public int Gloves { get; set; }
		public int Boots { get; set; }
		public int Amulet { get; set; }
		public int RingLeft { get; set; }
		public int RingRight { get; set; }

		// Foreign key properties
		public int CharId { get; set; }  // Foreign key to Character table
	}
}
