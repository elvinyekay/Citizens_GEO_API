using Citizen_Geo_API.DTOs;
using Citizen_Geo_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citizen_Geo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolygonsController : ControllerBase
    {
        private readonly IPolygonService _polygonService;

        public PolygonsController(IPolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolygonDto>>> GetAll()
        {
            var polygons = await _polygonService.GetAllAsync();
            return Ok(polygons);
        }

        [HttpPost]
        public async Task<ActionResult<PolygonDto>> Create([FromBody] CreatePolygonDto dto)
        {
            var polygon = await _polygonService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = polygon!.Id }, polygon);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _polygonService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}