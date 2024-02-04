using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Interfaces;

namespace NETUA2_Egzaminas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserAccountInfoController : ControllerBase
	{
		private readonly ILogger<UserAccountInfoController> _logger;
		private readonly IUserInfoRepository _userInfoRepository;
		private readonly IUserResidenceRepository _userResidenceRepository;

		public UserAccountInfoController(ILogger<UserAccountInfoController> logger, 
										IUserInfoRepository userInfoRepository, 
										IUserResidenceRepository userResidenceRepository)
		{
			_logger = logger;
			_userInfoRepository = userInfoRepository;
			_userResidenceRepository = userResidenceRepository;
		}



		//=========================User Info endpoints=========================================
		[HttpPost("CreateUserInfo")]
		public IActionResult CreateUserInfo()
		{
			return Ok();
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
