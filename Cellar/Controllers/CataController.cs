using Common.DTOs;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Cellar.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CataController : ControllerBase
    {
        private readonly ICataService _cataService;
        private readonly CellarContext _cellarContext;
        public CataController(ICataService cataService, CellarContext cellarContext)
        {
            _cataService = cataService;
            _cellarContext = cellarContext;
        }
        [HttpPost]
        public IActionResult CreateCataDto([FromBody] CreateCataDto dto)
        {
            _cataService.CreateCata(dto);
            var response = new
            {
                Message = "Cata creada exitosamente",
                Data = dto // Incluye el DTO procesado
            };
            return Ok(response);
        }

        [HttpPut("{Cataid}/guests")]
        public IActionResult UpdateGuestList(int Cataid, [FromBody] List<string> newGuest)
        {
            try
            {
                _cataService.UpdateGuestList(Cataid, newGuest);

                return Ok("Invitados añadidos correctamente a la cata.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getFuturecatas")]
        public IActionResult GetFuturecatas()
        {
            var getCatas = _cellarContext.Catas
                .Where(c => c.Date > DateTime.Now)
                .Select(c => new CreateCataDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Date = c.Date,
                    WineList = c.WineList.Select(w => w.Id).ToList()
                })
                .ToList();

            return Ok(getCatas);
        }

       

    }
}

