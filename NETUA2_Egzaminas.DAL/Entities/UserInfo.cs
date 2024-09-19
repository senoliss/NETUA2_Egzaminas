using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public string PersonalID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Foreign key properties
        public int UserId { get; set; }  // Foreign key to User table
        public int? ImageId { get; set; }  // Nullable foreign key to ProfileImage table
        public int? ResidenceId { get; set; }  // Nullable foreign key to UserResidence table
        public int? ItemId { get; set; }  // Nullable foreign key to Items table

        // Navigation properties
        //public User User { get; set; }  // Navigation to User entity        // Cross reference reiktu sutvarkyti kad nesigautu loop'as kai User modelis uzsikrauna UserInfo tada UserInfo uzsikrauna User ir t.t.
        [JsonIgnore]
        public ProfileImage Image { get; set; }  // Navigation to ProfileImage entity
        [JsonIgnore]    // a decorator to escape infinite loop of serialization when there's cross reference of navigational properties
        public UserResidence Residence { get; set; }  // Navigation to UserResidence entity
        [JsonIgnore]
        public Item Item { get; set; }                // Navitaional property to Items database
    }
}
