using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ProfileImage Image { get; set; }
        public UserResidence Residence { get; set; }
    }
}
