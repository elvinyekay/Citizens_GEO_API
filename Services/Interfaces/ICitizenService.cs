using Citizen_Geo_API.DTOs;

namespace Citizen_Geo_API.Services.Interfaces;

public interface ICitizenService
{
    Task<IEnumerable<CitizenDto>> GetAllAsync();
    Task<CitizenDto> GetByIdAsync(int id);
    Task<CitizenDto> AddAsync(CitizenDto citizenDto);
    Task<CitizenDto?> UpdateAsync(int id, CitizenDto citizenDto);
    Task<bool> DeleteAsync(int id);   
}