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
	public class CharSkills
	{
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
		// Inventory slots that reference ItemInstance (no cascade delete)
		[ForeignKey("Skill1Id")]
		[JsonIgnore]
		public int? Skill1Id { get; set; }
		public SkillInstance Woodcutting { get; set; }

        [ForeignKey("Skill2Id")]
		[JsonIgnore]
		public int? Skill2Id { get; set; }
		public SkillInstance Mining { get; set; }

		[ForeignKey("Skill3Id")]
		[JsonIgnore]
		public int? Skill3Id { get; set; }
		public SkillInstance Fishing { get; set; }

		[ForeignKey("Skill4Id")]
		[JsonIgnore]
		public int? Skill4Id { get; set; }
		public SkillInstance Cooking { get; set; }

		[ForeignKey("Skill5Id")]
		[JsonIgnore]
		public int? Skill5Id { get; set; }
		public SkillInstance Crafting { get; set; }

		[ForeignKey("Skill6Id")]
		[JsonIgnore]
		public int? Skill6Id { get; set; }
		public SkillInstance Smithing { get; set; }
	}
}
