using Citizen_Geo_API.Models;

namespace Citizen_Geo_API.Repositories.Interfaces;

public interface ICitizenRepository
{
    Task<IEnumerable<Citizen>> GetAllAsync();
    Task<Citizen?> GetByIdAsync(int id);
    Task<Citizen> AddAsync(Citizen item);
    Task<Citizen> UpdateAsync(Citizen item);
    Task<bool> DeleteAsync(int id);
}