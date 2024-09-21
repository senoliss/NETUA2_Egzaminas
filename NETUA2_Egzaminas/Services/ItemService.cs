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
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemService(AppDbContext context,
            ILogger<ItemService> logger,
            IHttpContextAccessor httpContextAccessor,
            IItemManagerRepository itemDbService)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _itemManagerRepository = itemDbService;
        }

        //=========================User methods=========================================
        public void AddItem(string name, string description, int value)
        {
            var found = _context.Items.Any(i => i.Name == name);
            if (found)
            {
                _logger.LogError("Item already exists");
                throw new System.Exception("Item already exists");
                //return null;
            }

            var item = new Item
            {
                Name = name,
                Description = description,
                Value = value
            };

            _itemManagerRepository.AddItem(item);

            //_context.Items.Add(item);
            //_context.SaveChanges();

            //return user;
        }
        public Item GetItemById(int id)
        {
            return _itemManagerRepository.GetItemById(id);
        }
        public List<Item> GetAll()
        {
            var items = _itemManagerRepository.GetAll();
            return items;
        }
    }
}
