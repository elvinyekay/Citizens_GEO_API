using Citizen_Geo_API.Data;
using Citizen_Geo_API.Models;
using Citizen_Geo_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citizen_Geo_API.Repositories.Implementations;

public class PolygonRepository :IPolygonRepository
{
    private readonly AppDbContext _context;
    
    public PolygonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Polygon>> GetAllAsync()
    {
        return await _context.Polygons.ToListAsync();
    }
    
    public async Task<Polygon?> GetByIdAsync(int id)
    {
        return await _context.Polygons.FindAsync(id);
    }
    
    public async Task<Polygon> CreateAsync(Polygon polygon)
    {
        _context.Polygons.Add(polygon);
        await _context.SaveChangesAsync();
        return polygon;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var polygon = await GetByIdAsync(id);
        if (polygon == null) return false;
        
        _context.Polygons.Remove(polygon);
        await _context.SaveChangesAsync();
        return true;
    }
}