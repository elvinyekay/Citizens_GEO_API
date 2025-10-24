using AutoMapper;
using Citizen_Geo_API.DTOs;
using Citizen_Geo_API.Models;
using Citizen_Geo_API.Repositories.Interfaces;
using Citizen_Geo_API.Services.Interfaces;


namespace Citizen_Geo_API.Services.Implementations;

public class CitizenService :ICitizenService
{
    private readonly ICitizenRepository _repository;
    private readonly IMapper _mapper;

    public CitizenService(ICitizenRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CitizenDto>> GetAllAsync()
    {
        var citizens = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CitizenDto>>(citizens);
    }

    public async Task<CitizenDto> GetByIdAsync(int id)
    {
        var citizen = await _repository.GetByIdAsync(id);
        return citizen == null ? null : _mapper.Map<CitizenDto>(citizen);
    }

    public async Task<CitizenDto> AddAsync(CitizenDto citizenDto)
    {
        var entity = _mapper.Map<Citizen>(citizenDto);
        if (entity.BirthDate.Kind == DateTimeKind.Unspecified)
        {
            entity.BirthDate = DateTime.SpecifyKind(entity.BirthDate, DateTimeKind.Utc);
        }
        var created =  await _repository.AddAsync(entity);
        
        return _mapper.Map<CitizenDto>(created);
    }

    public async Task<CitizenDto?> UpdateAsync(int id, CitizenDto citizenDto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)  return null;
        _mapper.Map(citizenDto, existing);
        if (existing.BirthDate.Kind == DateTimeKind.Unspecified)
        {
            existing.BirthDate = DateTime.SpecifyKind(existing.BirthDate, DateTimeKind.Utc);
        }
        var updated = await _repository.UpdateAsync(existing); 
        return _mapper.Map<CitizenDto>(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

}