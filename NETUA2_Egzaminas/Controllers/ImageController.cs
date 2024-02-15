 using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.BLL.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using NETUA2_Egzaminas.DAL.Repositories;
using System.Net.Mime;
using System.Security.Claims;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ImageController : ControllerBase
	{
		private readonly IImageRepository _imageRepository;
		private readonly IImageService _imageService;
        private readonly IImageMapper _imageMapper;
		private readonly ILogger<ImageController> _logger;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageController(IImageService imageService, 
								ILogger<ImageController> logger,
								IUserInfoRepository userInfoRepository,
                                IHttpContextAccessor httpContextAccessor, IImageMapper imageMapper)
		{
            _imageService = imageService;
            _imageMapper = imageMapper;
            _userInfoRepository = userInfoRepository;
            _logger = logger;
            _userId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Upload image file to DB for logged in user.
        /// </summary>
        /// <param name="dto">Image Data Trasnfer Object.</param>
        /// <returns>Returns uploaded Image Id if status 200OK.</returns>
		[HttpPost("uploadImage")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostImage([FromForm] PostImageDTO dto)
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                _logger.LogWarning($"User Id: {_userId} - has no personal information added yet!");
                return BadRequest("User has no personal information added yet!");
            }

			_logger.LogInformation($"Trying to POST Image for - Name: {existingUserInfo.Name}, User Id: {_userId}");

            // if user has image delete previous one and post new one in its place
            var mappedImage = _imageMapper.Map(dto);

            _imageService.AttemptAddImage(mappedImage, (int)existingUserInfo.ImageId);

			// Updates the ImageId field with value of image file id and saves to db.
            existingUserInfo.ImageId = mappedImage.Id;
            _userInfoRepository.UpdateUserInfo(existingUserInfo);

            _logger.LogInformation($"Image file succesfully uploaded for - Name: {existingUserInfo.Name}, User Id: {_userId}");
            return Created(nameof(DownloadImage), new { id = mappedImage.Id });
		}

        /// <summary>
        /// Downloads logged in user image.
        /// </summary>
        /// <response code="403">Forbidden for not Admins.</response>
        /// <returns>Returns Image file.</returns>
        [HttpGet("downloadImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces(MediaTypeNames.Image.Png)]
        public IActionResult DownloadImage()
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                _logger.LogWarning($"User Id: {_userId} - has no personal information added yet!");
                return BadRequest("User has no personal information added yet!");
            }

            _logger.LogInformation($"Trying to GET Image {(int)existingUserInfo.ImageId} for - Name: {existingUserInfo.Name}, User Id: {_userId}");

            var imageFile = _imageService.GetImage((int)existingUserInfo.ImageId);
			if (imageFile == null)
			{
                _logger.LogWarning($"Failed to GET for - Name: {existingUserInfo.Name}, User Id: {_userId}");
                return NotFound();
			}

            _logger.LogInformation($"Successfully downloaded Image for - Name: {existingUserInfo.Name}, User Id: {_userId}");
            return File(imageFile.ImageBytes, imageFile.Description, imageFile.Name);
		}
	
	    /// <summary>
        /// Deletes Image file for logged in user from DB.
        /// </summary>
		[HttpDelete("deleteImage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteImage()
		{
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                _logger.LogWarning($"User Id: {_userId} - has no personal information added yet!");
                return BadRequest("User has no personal information added yet!");
            }
            if (existingUserInfo.ImageId == null)
            {
                _logger.LogWarning($"There is no Image to delete for - Name: {existingUserInfo.Name}, User Id: {_userId}");
                return NotFound();
            }

            _imageService.DeleteImage((int)existingUserInfo.ImageId);
            _logger.LogInformation($"Image successfully deleted for - Name: {existingUserInfo.Name}, User Id: {_userId}");
			return NoContent();
		}
	}
}
