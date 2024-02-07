 using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ImageController : ControllerBase
	{
		private readonly IImageRepository _imageRepository;
		private readonly ILogger<ImageController> _logger;

		public ImageController(IImageRepository imageRepository, ILogger<ImageController> logger)
		{
			_imageRepository = imageRepository;
			_logger = logger;
		}


		[HttpPost("uploadImage")]
		public IActionResult PostImage([FromForm] PostImageDTO dto)
		{
			using var memoryStream = new MemoryStream();
			dto.Image.CopyTo(memoryStream);
			var imageBytes = memoryStream.ToArray();
			var imageFile = new ProfileImage
			{
				ImageBytes = imageBytes,
				Description = dto.Image.ContentType,
				Name = dto.Image.FileName,
				Size = imageBytes.Length
			};

			return Ok(_imageRepository.AddImage(imageFile));
		}

		[HttpGet("downloadImage/{id}")]
		public IActionResult DownloadImage(int id)
		{
			var imageFile = _imageRepository.GetImage(id);
			if (imageFile == null)
			{
				return NotFound();
			}

			return File(imageFile.ImageBytes, imageFile.Description, imageFile.Name);
		}
	
	
		[HttpDelete]
		public IActionResult DeleteImage(int id)
		{
			_imageRepository.DeleteImage(id);
			return NoContent();
		}
	}
}
