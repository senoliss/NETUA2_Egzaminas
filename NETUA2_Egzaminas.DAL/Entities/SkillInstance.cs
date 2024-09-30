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
	public class SkillInstance
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public double Xp { get; set; }
        public int XpCap { get; set; }
    }
}
