using Citizen_Geo_API.Data;
using Citizen_Geo_API.Models;
using Citizen_Geo_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Citizen_Geo_API.Repositories.Implementations;

public class CitizenRepository : ICitizenRepository
{
    private readonly AppDbContext _context;


    public CitizenRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Citizen>> GetAllAsync()
    {
        return await _context.Citizens.ToListAsync();
    }

    public async Task<Citizen?> GetByIdAsync(int id)
    {
        return await _context.Citizens.FindAsync(id);
    }

    public async Task<Citizen> AddAsync(Citizen item)
    {
        _context.Citizens.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Citizen> UpdateAsync(Citizen item)
    {
        _context.Citizens.Update(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var citizen = await _context.Citizens.FindAsync(id);
        if (citizen == null) return false;
        
        _context.Citizens.Remove(citizen);
        await _context.SaveChangesAsync();
        return true;
    }
}