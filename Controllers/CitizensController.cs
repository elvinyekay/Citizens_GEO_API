using Citizen_Geo_API.DTOs;
using Citizen_Geo_API.Models;
using Citizen_Geo_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citizen_Geo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitizensController :ControllerBase
{
    private readonly ICitizenService  _service;

    public CitizensController(ICitizenService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var citizen = await _service.GetAllAsync();
        return Ok(citizen);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var citizen = await _service.GetByIdAsync(id);
        if (citizen == null) return NotFound();
        return Ok(citizen);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CitizenDto dto)
    {
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Name }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CitizenDto dto)
    {
        var  updated = await _service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}