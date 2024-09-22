using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class CharAchievements
	{
        [Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public string DateOfCompletion { get; set; }
		public string Status { get; set; }
		public string Reward { get; set; }

		// Foreign key properties
		public int CharId { get; set; }  // Foreign key to Character table
	}
}
