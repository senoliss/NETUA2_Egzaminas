using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Interfaces;
using NETUA2_Egzaminas.DAL.Repositories;

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

        public UsersController(IUserService userService, IJwtService jwtService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginUserDTO dto)
        {
            var loginSuccess = _userService.TryLogin(dto.UserName, dto.Password, out int? userId, out string role);
            var loginMsg = "";
            if (!loginSuccess.IsSuccess)
            {
                loginMsg = $"Failed login attempt for username: {dto.UserName}";
                _logger.LogWarning(loginMsg);
                //return new LoginResponseDTO(false, loginMsg, (int)userId, role, null);
            }
            loginMsg = $"Successful login for username: {dto.UserName}, role: {role}";
            _logger.LogInformation(loginMsg);

            var token = _jwtService.GetJwtToken((int)userId, dto.UserName);

            //return new LoginResponseDTO(true, loginMsg, (int)userId, role, token);
            return Ok(token);

        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterUserDTO dto)
        {
            var user = _userService.CreateAccount(dto.UserName, dto.Password, dto.Email, dto.Role);
            if (user == null)       // kaip padaryti logika kad vadovaujantis SOLID principu cia nebutu null checko
            {
                return BadRequest("User already exists");
            }
            return Ok(user);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Implement deletion only for admins.
            // Mayne add reason why user was deleted and track data of deleted users for some time.
            // Also add temporary ban options.
            var userToDelete = _userService.GetUserById(id);
            _userService.DeleteUser(userToDelete);
            return Ok(userToDelete);
        }
    }
}
