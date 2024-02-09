 using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using NETUA2_Egzaminas.DAL.Repositories;
using System.Security.Claims;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ImageController : ControllerBase
	{
		private readonly IImageRepository _imageRepository;
		private readonly ILogger<ImageController> _logger;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageController(IImageRepository imageRepository, 
								ILogger<ImageController> logger,
								IUserInfoRepository userInfoRepository,
                                IHttpContextAccessor httpContextAccessor)
		{
			_imageRepository = imageRepository;
            _userInfoRepository = userInfoRepository;
            _logger = logger;
            _userId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _httpContextAccessor = httpContextAccessor;
        }


		[HttpPost("uploadImage")]
		public IActionResult PostImage([FromForm] PostImageDTO dto)
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

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

			_imageRepository.AddImage(imageFile);

			// Updates the ImageId field with value of image file id and saves to db.
            existingUserInfo.ImageId = imageFile.Id;
            _userInfoRepository.UpdateUserInfo(existingUserInfo);

            return Ok(imageFile.Id);
		}

		[HttpGet("downloadImage")]
		public IActionResult DownloadImage()
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            var imageFile = _imageRepository.GetImage((int)existingUserInfo.ImageId);
			if (imageFile == null)
			{
				return NotFound();
			}

			return File(imageFile.ImageBytes, imageFile.Description, imageFile.Name);
		}
	
	
		[HttpDelete("deleteImage")]
		public IActionResult DeleteImage()
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            _imageRepository.DeleteImage((int)existingUserInfo.ImageId);
			return NoContent();
		}
	}
}
