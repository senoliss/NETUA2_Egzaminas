using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Services;
using NETUA2_Egzaminas.DAL.Entities;
using System.Net.Mime;

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
        [HttpGet("GetItemByID")]
        public IActionResult GetItemById(int id)
        {
            loggingMessage = "";

            loggingMessage = $"Trying to GET all users.";
            _logger.LogInformation(loggingMessage);

            return Ok(_itemService.GetItemById(id));
        }
    }
}
