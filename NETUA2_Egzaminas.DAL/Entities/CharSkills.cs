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
		public int? Skill1Id { get; set; }
		public SkillInstance Skill1 { get; set; }

        [ForeignKey("Skill2Id")]
		public int? Skill2Id { get; set; }
		public SkillInstance Skill2 { get; set; }

		[ForeignKey("Skill3Id")]
		public int? Skill3Id { get; set; }
		public SkillInstance Skill3 { get; set; }

		[ForeignKey("Skill4Id")]
		public int? Skill4Id { get; set; }
		public SkillInstance Skill4 { get; set; }

		[ForeignKey("Skill5Id")]
		public int? Skill5Id { get; set; }
		public SkillInstance Skill5 { get; set; }

		[ForeignKey("Skill6Id")]
		public int? Skill6Id { get; set; }
		public SkillInstance Skill6 { get; set; }
	}
}
