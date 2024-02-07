using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Mappers;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Interfaces;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserAccountInfoController : ControllerBase
	{
		private readonly ILogger<UserAccountInfoController> _logger;
		//private readonly IUserInfoRepository _userInfoRepository;
		//private readonly IUserResidenceRepository _userResidenceRepository;
		private readonly IUserService _userService;
		private readonly IUserInfoMapper _userInfoMapper;

		public UserAccountInfoController(ILogger<UserAccountInfoController> logger, 
										//IUserInfoRepository userInfoRepository, 
										//IUserResidenceRepository userResidenceRepository,
										IUserService userService,
										IUserInfoMapper userInfoMapper)
		{
			_logger = logger;
			//_userInfoRepository = userInfoRepository;
			//_userResidenceRepository = userResidenceRepository;
			_userService = userService;
			_userInfoMapper = userInfoMapper;
		}



		//=========================User Info endpoints=========================================
		[HttpPost("CreateUserInfo")]
		public IActionResult CreateUserInfo([FromBody] PostUserInfoDTO userInfoDTO)
		{
			// Gets user id from JWT token authentication through claims
			var userId = _userService.GetCurrentUserId();

			// Checks if the user already has info created
			var existingUserInfo = _userService.GetUserInfoByUserId(userId);
            if (existingUserInfo != null)
            {
                return BadRequest("User already has information.");
            }
			// Here we should validate DTO and then map it to entity

			var userInfo = _userInfoMapper.Map(userInfoDTO);
			userInfo.UserId = userId;   // Separate mapping of FK UserId from JWT token

			// Would be best to process a picture here also


			// Maybe return some DTO to inform that user info was saved successfully
			return Ok(_userService.SaveUserInfoToDb(userInfo));
		}
		[HttpGet("GetUserInfo")]
		public IActionResult GetUserInfo()
		{
			return Ok();
		}
		[HttpPut("UpdateUserInfo")]
		public IActionResult UpdateUserInfo()
		{
			return Ok();
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
