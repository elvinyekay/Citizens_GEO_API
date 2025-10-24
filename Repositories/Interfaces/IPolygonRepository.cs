using Citizen_Geo_API.Models;

namespace Citizen_Geo_API.Repositories.Interfaces;

public interface IPolygonRepository
{
    Task<List<Polygon>> GetAllAsync();
    Task<Polygon?> GetByIdAsync(int id);
    Task<Polygon> CreateAsync(Polygon polygon);
    Task<bool> DeleteAsync(int id);
}