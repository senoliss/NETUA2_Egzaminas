using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Mappers;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Interfaces;
using System.Net.Mime;
using System.Security.Claims;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserAccountInfoController : ControllerBase
	{
		private readonly ILogger<UserAccountInfoController> _logger;
		private readonly IUserInfoRepository _userInfoRepository;
		private readonly IUserResidenceRepository _userResidenceRepository;
		private readonly IUserService _userService;
		private readonly IUserInfoMapper _userInfoMapper;
		private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccountInfoController(ILogger<UserAccountInfoController> logger,
										IUserInfoRepository userInfoRepository,
										IUserResidenceRepository userResidenceRepository,
										IUserService userService,
										IUserInfoMapper userInfoMapper,
										IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			_userInfoRepository = userInfoRepository;
			_userResidenceRepository = userResidenceRepository;
			_userService = userService;
			_userInfoMapper = userInfoMapper;
			_userId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _httpContextAccessor = httpContextAccessor;

        }



		//=========================User Info endpoints=========================================
		[HttpPost("CreateUserInfo")]
		[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult CreateUserInfo([FromBody] PostUserInfoDTO userInfoDTO)
		{
			// Gets user id from JWT token authentication through claims
			//var userId = _userId;

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo != null)
            {
                return BadRequest("User already has information.");
            }
			// Here we should validate DTO and then map it to entity

			var userInfo = _userInfoMapper.Map(userInfoDTO);
			userInfo.UserId = _userId;   // Separate mapping of FK UserId from JWT token

			// Would be best to process a picture here also


			// Maybe return some DTO to inform that user info was saved successfully
			// tried to refactor code to call .DAL repo directly from .API
			_userInfoRepository.AddUserInfo(userInfo);

            return Created();
		}
		[HttpGet("GetUserInfo")]
		public IActionResult GetUserInfo()
		{
            // Gets user id from JWT token authentication through claims
            var userId = _userService.GetCurrentUserId();

            // Checks if the user already has info created
            var existingUserInfo = _userService.GetUserInfoByUserId(userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no information yet!");
            }
            return Ok(existingUserInfo);
		}
		[HttpPut("UpdateUserInfo")]
		public IActionResult UpdateUserInfo([FromBody] UpdateUserInfoDTO userInfoToUpdateDTO)
		{
            // Gets user id from JWT token authentication through claims
            var userId = _userService.GetCurrentUserId();

            // Checks if the user already has info created
            var existingUserInfo = _userService.GetUserInfoByUserId(userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no information yet!");
            }

			var entity = _userInfoMapper.Map(userInfoToUpdateDTO);

            return Ok(existingUserInfo);
		}
		[HttpDelete("DeleteUserInfo")]
		public IActionResult DeleteUserInfo()
		{
			return Ok();
		}
		//=========================User Residence endpoints=========================================
		[HttpPost("CreateUserResidence")]
		public IActionResult CreateUserResidence()
		{
			return Ok();
		}
		[HttpGet("GetUserResidence")]
		public IActionResult GetUserResidence()
		{
			return Ok();
		}
		[HttpPut("UpdateUserResidence")]
		public IActionResult UpdateUserResidence()
		{
			return Ok();
		}
		[HttpDelete("DeleteUserResidence")]
		public IActionResult DeleteUserResidence()
		{
			return Ok();
		}
	}
}
