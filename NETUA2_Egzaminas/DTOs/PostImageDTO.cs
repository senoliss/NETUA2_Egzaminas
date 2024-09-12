using NETUA2_Egzaminas.API.CustomValidators;

namespace NETUA2_Egzaminas.API.DTOs
{
	public class PostImageDTO
	{
        //public string Name { get; set; }
        //public string Description { get; set; }

		[MaxFileSize(5 * 1024 * 1024)]  // 5 MB
		[AllowedExtensions(new[] { ".jpg", ".png", ".jpeg" })]
		public IFormFile Image { get; set; }
    }
}
