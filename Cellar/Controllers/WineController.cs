using Common.DTOs;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Cellar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;
        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }
        [HttpPost]
        public IActionResult CreateWine([FromBody] CreateWineDto dto)
        {
            _wineService.CreateWine(dto);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetAllWines()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);
        }

        [HttpGet("variety/{Variety}")]
        public IActionResult GetStock(string Variety)
        {
            var stock = _wineService.GetStock(Variety);
            return Ok($"El stock de la variedad ingresada es: {stock}");
        }

        [HttpPut("stock/{wineId}")]
        public IActionResult UpdateStock(int wineId, [FromBody] UpdateStockDto dto)
        {
            if (!_wineService.CheckIfWineExists(wineId))
            {
                return NotFound("El vino ingresado no existe");

            }
            try
            {
                _wineService.UpdateStock(dto, wineId: wineId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
