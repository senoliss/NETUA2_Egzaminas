using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NETUA2_Egzaminas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        [HttpPost("CreateNote")]
        public IActionResult CreateNote()
        {
            return Ok();
        }
        [HttpPut("UpdateNote")]
        public IActionResult UpdateNote()
        {
            return Ok();
        }
        [HttpDelete("DeleteNote")]
        public IActionResult DeleteNote()
        {
            return Ok();
        }
        [HttpGet("/GetNotesByName")]
        public IActionResult GetNotesByName()
        {
            return Ok("Pasiseke");
        }
        [HttpGet("/GetNotesByCategory")]
        public IActionResult GetNotesByCategory()
        {
            return Ok();
        }
    }
}
