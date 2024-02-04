using System.ComponentModel.DataAnnotations;

namespace NETUA2_Egzaminas.API.CustomValidators
{
	public class MaxFileSizeAttribute : ValidationAttribute
	{
		private readonly int _maxFileSize;

		public MaxFileSizeAttribute(int maxFileSize)
		{
			_maxFileSize = maxFileSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is FormFile file && file.Length > _maxFileSize)
			{
				return new ValidationResult($"File size cannot be larger than {_maxFileSize} bytes.");
			}

			return ValidationResult.Success;
		}
	}
}
