using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class UserResidence
	{
        [Key]
        public int Id { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
