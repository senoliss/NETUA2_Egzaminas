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
        /// <summary>
        /// This prop is string because sometimes houses are divided in subplaces like 29A 29B 29C etc
        /// </summary>
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

        // Navigation property
        public UserInfo UserInfo { get; set; }  // Navigation to UserInfo entity
    }
}
