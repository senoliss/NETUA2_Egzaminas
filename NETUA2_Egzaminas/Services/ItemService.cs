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
		private readonly IItemMapper _mapper;

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
        public void AddItem(Item item)
        {
            //var found = _context.Items.Any(i => i.Name == item.Name);
            //if (found)
            //{
            //    _logger.LogError("Item already exists");
            //    throw new System.Exception("Item already exists");
            //    //return null;
            //}

            _itemManagerRepository.AddItem(item);

            //_context.Items.Add(item);
            //_context.SaveChanges();

            //return user;
        }
        public Item GetItemById(int id)
        {
            return _itemManagerRepository.GetItemById(id);
        }
        public bool GetItemByName(string name)
        {
            return _context.Items.Any(i => i.Name == name);
		}
        public List<Item> GetAll()
        {
            var items = _itemManagerRepository.GetAll();
            return items;
        }
        public int GetItemsCount()
        {
            int itemcount = _itemManagerRepository.GetItemCount();
            return itemcount;
        }
    }
}
