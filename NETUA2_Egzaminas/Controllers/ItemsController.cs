using Microsoft.AspNetCore.Mvc;
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
        private string loggingMessage;

        public ItemsController(IItemService itemService, IJwtService jwtService, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(PostItemDTO dto)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to Add item - {dto.Name}";
            _logger.LogInformation(loggingMessage);

            _itemService.AddItem(dto.ImgId, dto.Name, dto.Type, dto.Description, dto.Value);

            loggingMessage = $"Successfully Added item: {dto.Name}";
            _logger.LogInformation(loggingMessage);

            return Ok();
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

            loggingMessage = "Successfully fetched items";
            _logger.LogInformation(loggingMessage);

            return Ok(items);
        }
    }
}
