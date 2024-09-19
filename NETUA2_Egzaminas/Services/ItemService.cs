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
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        private readonly IItemManagerRepository _itemManagerRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemService(AppDbContext context,
            ILogger<ItemService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        //=========================User methods=========================================
        public void AddItem()
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
                Role = "User"
            };

            _itemManagerRepository.AddItem(user);

            return user;
        }
        public Item GetItemById(int id)
        {
            return _userManagerService.GetUser(userName);
        }
        public List<Item> GetAll()
        {
            var items = _context.Users.Include(u => u.UserInfo).ToList();
            return items;
        }
        public void DeleteUser(User user)
        {
            _userManagerService.DeleteUser(user);
        }
    }
}
