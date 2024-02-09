using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Mappers;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Entities;
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
        private readonly IUserInfoMapper _userInfoMapper;
        private readonly IUserResidenceMapper _userResidenceMapper;
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccountInfoController(ILogger<UserAccountInfoController> logger,
                                        IUserInfoRepository userInfoRepository,
                                        IUserResidenceRepository userResidenceRepository,
                                        IUserInfoMapper userInfoMapper,
                                        IUserResidenceMapper userResidenceMapper,
                                        IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userInfoRepository = userInfoRepository;
            _userResidenceRepository = userResidenceRepository;
            _userInfoMapper = userInfoMapper;
            _userResidenceMapper = userResidenceMapper;
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
            //var userId = _userService.GetCurrentUserId();

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no information created!");
            }
            return Ok(existingUserInfo);
        }
        [HttpPut("UpdateUserInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateUserInfo([FromBody] UpdateUserInfoDTO userInfoToUpdateDTO)
        {
            // Gets user id from JWT token authentication through claims
            //var userId = _userService.GetCurrentUserId();

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no information to update!");
            }
            // Updates the fetched info of user with DTO from frontend because otherwise EF would think that we're creating new UserInfo entity..
            _userInfoMapper.Map(userInfoToUpdateDTO, existingUserInfo);
            //entity.UserId = _userId;

            // Sends the updated userinfo entity to method which saves to DB
            _userInfoRepository.UpdateUserInfo(existingUserInfo);

            return NoContent();
        }
        /// <summary>
        /// Deletes all UserInfo from the User
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteUserInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUserInfo()
        {
            var userInfoToDelete = _userInfoRepository.GetUserInfoById(_userId);
            if (userInfoToDelete == null)
            {
                return NotFound("User Info not found");
            }

            _userInfoRepository.DeleteUserInfo(userInfoToDelete);
            return NoContent();
        }
        //=========================User Residence endpoints=========================================
        [HttpPost("CreateUserResidence")]
        public IActionResult CreateUserResidence([FromBody] PostUserResidenceDTO userResidenceDTO)
        {
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            // Checks if the user already has Residence created
            var existingUserResidence = _userResidenceRepository.GetUserResidenceById(_userId);
            if (existingUserResidence != null)
            {
                return BadRequest("User already has Residence information.");
            }
            // Adds User REsidence to DB
            var userResidence = _userResidenceMapper.Map(userResidenceDTO);
            _userResidenceRepository.AddUserResidence(userResidence);

            // Updates User Info with User Residence ID in DB
            existingUserInfo.ResidenceId = (int)userResidence.Id;
            _userInfoRepository.UpdateUserInfo(existingUserInfo);
            return Ok();
        }

        [HttpGet("GetUserResidence")]
        public IActionResult GetUserResidence()
        {
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            //var existingUserResidence = _userResidenceRepository.GetUserResidenceById((int)existingUserInfo.ResidenceId);
            var existingUserResidence = existingUserInfo.Residence;
            if (existingUserResidence == null)
            {
                return NotFound("User Residence not found");
            }

            return Ok(existingUserResidence);
        }

        [HttpPut("UpdateUserResidence")]
        public IActionResult UpdateUserResidence([FromBody] UpdateUserResidenceDTO updateUserResidenceDTO)
        {
            // Checks if the user already has residence created through userinfo
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            //var userResidenceToUpdate = _userResidenceRepository.GetUserResidenceById((int)existingUserInfo.ResidenceId);
            var userResidenceToUpdate = existingUserInfo.Residence;
            if (userResidenceToUpdate == null)
            {
                return NotFound("User Residence not found");
            }

            // Update properties of userResidenceToUpdate with values from updateUserResidenceDTO
            _userResidenceMapper.Map(updateUserResidenceDTO, userResidenceToUpdate);
            _userResidenceRepository.UpdateUserResidence(userResidenceToUpdate);
            return Ok();
        }

        [HttpDelete("DeleteUserResidence")]
        public IActionResult DeleteUserResidence()
        {
            // Checks if the user already has residence created through userinfo
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            var userResidenceToDelete = existingUserInfo.Residence;
            if (userResidenceToDelete == null)
            {
                return NotFound("User Residence not found");
            }

            _userResidenceRepository.DeleteUserResidence(userResidenceToDelete);
            return Ok(userResidenceToDelete);
        }
    }
}
