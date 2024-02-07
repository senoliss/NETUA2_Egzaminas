using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;

namespace NETUA2_Egzaminas.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserManagerService _userManagerService;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(AppDbContext context, IUserManagerService userDbService, ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManagerService = userDbService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public User? CreateAccount(string userName, string password, string email, string role)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var found = _context.Users.Any(u => u.UserName == userName);
            if (found)
            {
                _logger.LogError("User already exists");
                //throw new System.Exception("User already exists");
                return null;
            }

            var user = new User
            {
                UserName = userName,
                Email = email,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role
            };

            _userManagerService.SaveUser(user);

            return user;
        }

        public int GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return int.Parse(userId);
        }

        public User GetUserById(int id)
        {
            var userId = _userManagerService.GetUserById(id);
            return userId;
        }

        public void DeleteUser(User user)
        {
            _userManagerService.DeleteUser(user);
        }

        public ResponseDTO TryLogin(string userName, string password, out int? userId, out string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                _logger.LogWarning($"User {userName} does not exist.");
                userId = null;
				role = user.Role;
				return new ResponseDTO(false, $"User {userName} does not exist.");
            }
            
            userId = user.UserId;
            role = user.Role;
            var verified = TryVerifyPasswordHash(password, user.Password, user.PasswordSalt);
            if (!verified)
            {
                _logger.LogWarning($"Password for user {userName} is wrong.");
                return new ResponseDTO(false, $"Password for user {userName} is wrong.");
            }
            return new ResponseDTO(true, "User connected successfully!");
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool TryVerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA256(storedSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(storedHash);
        }

    }
}
