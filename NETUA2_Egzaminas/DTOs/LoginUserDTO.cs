using NETUA2_Egzaminas.API.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.API.DTOs
{
    /// <summary>
    /// Request for login User
    /// </summary>
    public class LoginUserDTO
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [PasswordValidator]
        public string Password { get; set; }
    }
}
