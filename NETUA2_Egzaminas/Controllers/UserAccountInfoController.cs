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
        private readonly int _userId;                                           // Gets user id from JWT token authentication through claims
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string loggingMessage;

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

        /// <summary>
        /// Creates User Information.
        /// </summary>
        /// <param name="userInfoDTO">User Information DTO from FE.</param>
        /// <returns></returns>
        [HttpPost("CreateUserInfo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult CreateUserInfo([FromBody] PostUserInfoDTO userInfoDTO)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to POST logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            // Checks if the user already has info created
            loggingMessage = $"Trying to GET logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo != null)
            {
                loggingMessage = $"Found logged in User Information for - user ID: {existingUserInfo.UserId}, name: {existingUserInfo.Name}, surname: {existingUserInfo.Surname}";
                _logger.LogInformation(loggingMessage);

                loggingMessage = $"Logged in User already has information for - user ID: {existingUserInfo.UserId}!";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User already has information.");
            }

            // Here we validate DTO and then map it to entity

            var userInfo = _userInfoMapper.Map(userInfoDTO);

            userInfo.UserId = _userId;   // Separate mapping of FK UserId from JWT token

            // Would be best to process a picture here also
            // Maybe return some DTO to inform that user info was saved successfully
            // tried to refactor code to call .DAL repo directly from .API
            _userInfoRepository.AddUserInfo(userInfo);

            loggingMessage = $"Succesfully POSTed logged in User Information for - user ID: {userInfo.UserId}, name: {userInfo.Name}, surname: {userInfo.Surname}";
            _logger.LogInformation(loggingMessage);

            return Created();
        }

        /// <summary>
        /// Gets logged in user information.
        /// </summary>
        /// <response code="200">Returns logged in User Info.</response>
        /// <response code="400">User has no information created.</response>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetUserInfo()
        {
            loggingMessage = "";

            loggingMessage = $"Trying to GET logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                loggingMessage = $"Logged in User has no Information for - user ID: {_userId}";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User has no information created!");
            }

            loggingMessage = $"Succesfully got logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            return Ok(existingUserInfo);
        }

        /// <summary>
        /// Updates logged in user information.
        /// </summary>
        /// <response code="400">User has no information created.</response>
        /// <param name="userInfoToUpdateDTO">User Information DTO from FE.</param>
        /// <returns></returns>
        [HttpPut("UpdateUserInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserInfo([FromBody] UpdateUserInfoDTO userInfoToUpdateDTO)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to UPDATE logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                loggingMessage = $"Logged in User has no Information for - user ID: {_userId}";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User has no information to update!");
            }

            loggingMessage = $"Trying to MAP logged in User Information FROM - user ID: {existingUserInfo.UserId}, name: {existingUserInfo.Name}, surname: {existingUserInfo.Surname}";
            _logger.LogInformation(loggingMessage);

            loggingMessage = $"Trying to MAP logged in User Information TO - name: {userInfoToUpdateDTO.Name}, surname: {userInfoToUpdateDTO.Surname}";
            _logger.LogInformation(loggingMessage);

            // Updates the fetched info of user with DTO from frontend because otherwise EF would think that we're creating new UserInfo entity..
            _userInfoMapper.Map(userInfoToUpdateDTO, existingUserInfo);

            // Sends the updated userinfo entity to method which saves to DB
            _userInfoRepository.UpdateUserInfo(existingUserInfo);

            loggingMessage = $"Succesfully UPDATED logged in User Information for - user ID: {existingUserInfo.UserId}, name: {existingUserInfo.Name}, surname: {existingUserInfo.Surname}";
            _logger.LogInformation(loggingMessage);

            return NoContent();
        }

        /// <summary>
        /// Deletes all UserInfo from the User
        /// </summary>
        /// <response code="404">User information not found.</response>
        /// <returns></returns>
        [HttpDelete("DeleteUserInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUserInfo()
        {
            loggingMessage = "";

            loggingMessage = $"Trying to DELETE logged in User Information for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            var userInfoToDelete = _userInfoRepository.GetUserInfoById(_userId);
            if (userInfoToDelete == null)
            {
                loggingMessage = $"Logged in User has no Information for - user ID: {_userId}";
                _logger.LogWarning(loggingMessage);

                return NotFound("User Info not found");
            }

            _userInfoRepository.DeleteUserInfo(userInfoToDelete);

            loggingMessage = $"Succesfully DELETED logged in User Information for - user ID: {userInfoToDelete.UserId}, name: {userInfoToDelete.Name}, surname: {userInfoToDelete.Surname}";
            _logger.LogInformation(loggingMessage);

            return NoContent();
        }
        //=========================User Residence endpoints=========================================

        /// <summary>
        /// Creates User Residence.
        /// </summary>
        /// <response code="200">User Residence ahs been created.</response>
        /// <param name="userResidenceDTO">User Residence DTO from FE.</param>
        /// <returns></returns>
        [HttpPost("CreateUserResidence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUserResidence([FromBody] PostUserResidenceDTO userResidenceDTO)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to POST logged in User Residence for - user ID: {_userId}";
            _logger.LogInformation(loggingMessage);

            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                loggingMessage = $"Logged in User has no Information for - user ID: {_userId}. Cannot add Residence Information!";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User has no personal information added yet!");
            }

            // Checks if the user already has Residence created
            var existingUserResidence = _userResidenceRepository.GetUserResidenceById(_userId);
            if (existingUserResidence != null)
            {
                loggingMessage = $"Logged in User already has Residence information for - user ID: {_userId}";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User already has Residence information.");
            }

            loggingMessage = $"Trying to MAP logged in User Information FROM - user ID: {_userId}, town: {userResidenceDTO.Town}, street: {userResidenceDTO.Street}, houseNr: {userResidenceDTO.BuildingNumber}, flatNr: {userResidenceDTO.FlatNumber}";
            _logger.LogInformation(loggingMessage);


            // Adds User REsidence to DB
            var userResidence = _userResidenceMapper.Map(userResidenceDTO);

            loggingMessage = $"Trying to MAP logged in User Information TO - user ID: {_userId}, town: {userResidenceDTO.Town}, street: {userResidenceDTO.Street}, houseNr: {userResidenceDTO.BuildingNumber}, flatNr: {userResidenceDTO.FlatNumber}";
            _logger.LogInformation(loggingMessage);

            _userResidenceRepository.AddUserResidence(userResidence);

            // Updates User Info with User Residence ID in DB
            existingUserInfo.ResidenceId = (int)userResidence.Id;
            _userInfoRepository.UpdateUserInfo(existingUserInfo);
            return Ok();
        }

        /// <summary>
        /// Gets logged in User Residence.
        /// </summary>
        /// <response code="200">User Residence entity.</response>
        /// <returns></returns>
        [HttpGet("GetUserResidence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetUserResidence()
        {
            // Checks if the user already has info created
            var existingUserInfo = _userInfoRepository.GetUserInfoById(_userId);
            if (existingUserInfo == null)
            {
                return BadRequest("User has no personal information added yet!");
            }

            var existingUserResidence = existingUserInfo.Residence;
            if (existingUserResidence == null)
            {
                return NotFound("User Residence not found");
            }

            return Ok(existingUserResidence);
        }

        /// <summary>
        /// Updates logged in User Residence.
        /// </summary>
        /// <param name="updateUserResidenceDTO">User Residence DTO from FE.</param>
        /// <returns></returns>
        [HttpPut("UpdateUserResidence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Deletes logged in User Residence.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteUserResidence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
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
