using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class CharSkills
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public double Xp { get; set; }
        public int XpCap { get; set; }

		// Foreign key properties
		public int CharId { get; set; }  // Foreign key to Character table
	}
}
