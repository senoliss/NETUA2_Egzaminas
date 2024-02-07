using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NETUA2_Egzaminas.DAL.Entities
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonalID { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; } // Foreign key to User table by UserId prop
        public ProfileImage Image { get; set; }
        public UserResidence Residence { get; set; }
    }
}
