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
	public class CharAchievement
	{
		[Key]
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public string DateOfCompletion { get; set; }
		public string Status { get; set; }
		public string Reward { get; set; }

        // Foreign key for Character
        [ForeignKey("CharId")]  // Specify that CharId is the FK for Character
        [JsonIgnore]
        public int CharId { get; set; }  // Foreign key to Character table
        [JsonIgnore]
        public Character? Character { get; set; }

    }
}
