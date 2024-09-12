using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;
using System.Net.Mime;

namespace NETUA2_Egzaminas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        //private readonly IAcountsValidationService _validationService;
        private readonly ILogger<UsersController> _logger;
        private string loggingMessage;

        public UsersController(IUserService userService, IJwtService jwtService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _jwtService = jwtService;
            _logger = logger;
        }

        /// <summary>
        /// Logins user, checks password hash.
        /// </summary>
        /// <param name="dto">User Login Data Trasnfer Object.</param>
        /// <returns>String of JWT token with OK response.</returns>
        [HttpPost("Login")]
        [Produces(MediaTypeNames.Text.Plain)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Login(LoginUserDTO dto)
        {
            loggingMessage = "";
            var user = _userService.GetUser(dto.UserName);

            var loginSuccess = _userService.TryLogin(user, dto.Password);
            if (!loginSuccess.IsSuccess)
            {
                loggingMessage = $"Failed login attempt for - username: {dto.UserName}. " + loginSuccess.Message;
                _logger.LogWarning(loggingMessage);

                return NotFound(loginSuccess.Message);
            }

            loggingMessage = $"Successful login for - username: {user.UserName}, role: {user.Role}";
            _logger.LogInformation(loggingMessage);

            var token = _jwtService.GetJwtToken(user);

            return Ok(token);

        }

        /// <summary>
        /// Creates user.
        /// </summary>
        /// <param name="dto">User Register Data Trasnfer Object.</param>
        /// <returns>The created User object with OK response.</returns>
        [HttpPost("Register")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public IActionResult Register(RegisterUserDTO dto)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to Register for - username: {dto.UserName}";
            _logger.LogInformation(loggingMessage);

            // maybe map an account here
            var user = _userService.CreateAccount(dto.UserName, dto.Password, dto.Email);
            if (user == null)       // kaip padaryti logika kad vadovaujantis SOLID principu cia nebutu null checko
            {
                loggingMessage = $"Failed Registration for - username: {user.UserName}, {user.Role}. User already exists.";
                _logger.LogWarning(loggingMessage);

                return BadRequest("User already exists");
            }

            loggingMessage = $"Successfully Registered user - username: {user.UserName}, {user.Role}";
            _logger.LogInformation(loggingMessage);

            return Ok(user);
        }

        /// <summary>
        /// Removes user account from DB. Accesible for Admins.
        /// </summary>
        /// <param name="id">Id of the user to delete.</param>
        /// <response code="403">Forbidden for not Admins.</response>
        /// <returns>The deleted User object with OK response.</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to Delete - User Id: {id}";
            _logger.LogInformation(loggingMessage);

            var userToDelete = _userService.GetUserById(id);

            if (userToDelete == null)
            {
                loggingMessage = $"User not found for - User Id: {id}, {userToDelete.UserName}, {userToDelete.Role}";
                _logger.LogWarning(loggingMessage);

                return NotFound();
            }

            loggingMessage = $"User found for - User Id: {id}, {userToDelete.UserName}, {userToDelete.Role}";
            _logger.LogInformation(loggingMessage);

            _userService.DeleteUser(userToDelete);


            loggingMessage = $"User Deleted - User Id: {id}, {userToDelete.UserName}, {userToDelete.Role}";
            _logger.LogInformation(loggingMessage);

            return Ok(userToDelete);

            // Mayne add reason why user was deleted and track data of deleted users for some time.
            // Also add temporary ban options.
        }

        /// <summary>
        /// Gets all the users from db. For Admins.
        /// </summary>
        /// <returns>Returns list of Users with Ok response.<see cref="List{User}"/></returns>
        /// <response code="401">Unauthorized access.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAll()
        {
            loggingMessage = "";

            loggingMessage = $"Trying to GET all users.";
            _logger.LogInformation(loggingMessage);

            return Ok(_userService.GetAll());
        }
    }
}
