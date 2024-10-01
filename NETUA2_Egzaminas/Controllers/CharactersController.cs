using Microsoft.AspNetCore.Mvc;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Mappers;
using NETUA2_Egzaminas.DAL.Entities;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETUA2_Egzaminas.API.Controllers
{
    /// <summary>
    /// API controller for managing characters.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        /// <summary>
        /// Creates a new character.
        /// </summary>
        /// <param name="dto">The data transfer object containing character creation data.</param>
        /// <returns>The created character object.</returns>
        [HttpPost("CreateCharacter")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCharacter([FromBody] PostCreateCharacterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = await _characterService.CreateCharacterAsync(dto);
            return CreatedAtAction(nameof(GetCharacterById), new { id = character.CharId }, character);
        }

        /// <summary>
        /// Retrieves a a full character entity with relations by ID.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns>The character object.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _characterService.GetCharacterAsync(id);

            if (character == null)
                return NotFound($"Character with id {id} does not exist!");

            return Ok(character);
        }

        /// <summary>
        /// Retrieves all characters.
        /// </summary>
        /// <returns>A list of characters.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Character>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        /// <summary>
        /// Retrieves character inventory by character id.
        /// </summary>
        /// <returns>A list of inventory items.</returns>
        [HttpGet("Inventory/{id}")]
        [ProducesResponseType(typeof(CharInventory), StatusCodes.Status200OK)]     // or typeof(IEnumerable<CharInventory>)
        public async Task<IActionResult> GetCharacterInventoryById(int id)
        {
            var inventory = await _characterService.GetCharacterInventoryByIdAsync(id);
            
            if(inventory == null)
                return NotFound();
            
            return Ok(inventory);
        }

        /// <summary>
        /// Retrieves character equipment by character id.
        /// </summary>
        /// <returns>A list of equimpent.</returns>
        [HttpGet("Equipment/{id}")]
        [ProducesResponseType(typeof(CharEquipment), StatusCodes.Status200OK)]     // or typeof(IEnumerable<CharEquipment>)
        public async Task<IActionResult> GetCharacterEquipmentById(int id)
        {
            var equipment = await _characterService.GetCharacterEquipmentByIdAsync(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [HttpGet("{id}/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCahracterData(int id, [FromQuery] string dataType)
        {
            object result;

            switch (dataType.ToLower())
            {
                case "inventory":
                    result = await _characterService.GetCharacterInventoryByIdAsync(id);
                    break;
                case "equipment":
                    result = await _characterService.GetCharacterEquipmentByIdAsync(id);
                    break;
                case "skills":
                    result = await _characterService.GetCharacterSkillsByIdAsync(id);
                    break;
                case "quests":
                    result = await _characterService.GetCharacterQuestsByIdAsync(id);
                    break;
                case "achievements":
                    result = await _characterService.GetCharacterAchievementsByIdAsync(id);
                    break;
                case "base stats":
                    result = await _characterService.GetCharacterBaseStatsByIdAsync(id);
                    break;
                case "stats":
                    result = await _characterService.GetCharacterStatsByIdAsync(id);
                    break;
                default:
                    return BadRequest("Invalid data type specified.");
            }

            if (result  == null) return NotFound("Nera tokio bled");

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing character.
        /// </summary>
        /// <param name="id">The ID of the character to update.</param>
        /// <param name="dto">The updated character data.</param>
        /// <returns>The updated character object.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] PostCreateCharacterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Tries to validate empty inventory slots, does not accept null
            var updatedCharacter = await _characterService.UpdateCharacterAsync(id, dto);

            if (updatedCharacter == null)
                return NotFound();

            return Ok(updatedCharacter);
        }

        /// <summary>
        /// Deletes a character by ID.
        /// </summary>
        /// <param name="id">The ID of the character to delete.</param>
        /// <returns>Status code indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacterAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
