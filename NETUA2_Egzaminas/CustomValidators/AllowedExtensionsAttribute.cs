using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.API.CustomValidators
{
	public class AllowedExtensionsAttribute : ValidationAttribute
	{
		private readonly string[] _extensions;

		public AllowedExtensionsAttribute(string[] extensions)
		{
			_extensions = extensions;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is FormFile file)
			{
				var extension = Path.GetExtension(file.FileName);
				if (!_extensions.Contains(extension.ToLower()))
				{
					return new ValidationResult($"File extension {extension} is not allowed.");
				}
			}

			return ValidationResult.Success;
		}
	}
}
