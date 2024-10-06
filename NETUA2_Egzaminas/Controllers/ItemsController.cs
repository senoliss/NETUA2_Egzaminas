using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IJwtService _jwtService;
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemMapper _mapper;
        private string loggingMessage;

        public ItemsController(IItemService itemService, IJwtService jwtService, ILogger<ItemsController> logger, IItemMapper mapper)
        {
            _itemService = itemService;
            _jwtService = jwtService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(PostItemDTO dto)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to Add item - {dto.Name}";
            _logger.LogInformation(loggingMessage);

            bool found = _itemService.GetItemByName(dto.Name);

            if (found)
            {
                _logger.LogError("Item already exists");
				return Ok("Item already exists!");
                //return null;
            }

            var item = _mapper.ItemMapping(dto);

            _itemService.AddItem(item);

            loggingMessage = $"Successfully Added item: {item.Name}";
            _logger.LogInformation(loggingMessage);

            return Ok(item);
        }

		[HttpPost("AddItemList")]
		public async Task<IActionResult> AddItemList(PostItemListDTO dtoske)
		{
			if (dtoske == null || dtoske.Items == null || dtoske.Items.Count == 0)
			{
				return BadRequest("No items provided in the list.");
			}

			try
			{
				foreach (var dto in dtoske.Items)
				{
                       var item = _mapper.ItemMapping(dto);

				    _itemService.AddItem(item);
				}

				return Ok("Items added successfully.");
			}
			catch (Exception ex)
			{
				_logger.LogError("Error adding items: {0}", ex.Message);
				return BadRequest("Error adding items.");
			}
			
		}

		[HttpGet("GetItemByID")]
        public IActionResult GetItemById(int id)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to GET all users.";
            _logger.LogInformation(loggingMessage);

            return Ok(_itemService.GetItemById(id));
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAll()
        {
            loggingMessage = "";

            loggingMessage = "Trying to Get All items";
            _logger.LogInformation(loggingMessage);

            // maybe map an account here
            List<Item> items = _itemService.GetAll();

            if (items == null || items.Count == 0)
			{
				loggingMessage = "No items in database!";
				_logger.LogInformation(loggingMessage);
				return Ok(loggingMessage);
            }

			loggingMessage = "Successfully fetched items";
            _logger.LogInformation(loggingMessage);

            return Ok(items);
        }

        [HttpGet("GetAllItemsCount")]
        public IActionResult GetAllItemsCount()
        {
			loggingMessage = "";

			loggingMessage = "Trying to Get All items count";
			_logger.LogInformation(loggingMessage);

            int itemCount = _itemService.GetItemsCount();

            if (itemCount == null || itemCount == 0)
			{
				loggingMessage = "No items in database!";
				_logger.LogInformation(loggingMessage);
				return Ok(loggingMessage);
			}

			loggingMessage = $"Successfully fetched items Count! - {itemCount}";
			_logger.LogInformation(loggingMessage);

			return Ok(itemCount);
		}
    }
}
