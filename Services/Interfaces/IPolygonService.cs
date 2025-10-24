using Citizen_Geo_API.DTOs;

namespace Citizen_Geo_API.Services.Interfaces;

public interface IPolygonService
{
    Task<List<PolygonDto>> GetAllAsync();
    Task<PolygonDto?> CreateAsync(CreatePolygonDto dto);
    Task<bool> DeleteAsync(int id);
}