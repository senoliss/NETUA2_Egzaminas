using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.API.CustomValidators
{
    public class PasswordValidatorAttribute : ValidationAttribute
    {
        public int MinLength { get; set; } = 3;
        public int MaxLength { get; set; } = 15;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value.ToString();

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password is required.");
            }

            if (password.Length < MinLength)
            {
                return new ValidationResult($"Password must be at least {MinLength} characters long.");
            }

            if (password.Length > MaxLength)
            {
                return new ValidationResult($"Password must be at most {MaxLength} characters long.");
            }

            return ValidationResult.Success;
        }

    }
}
