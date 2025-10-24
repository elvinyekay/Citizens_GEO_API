using Citizen_Geo_API.DTOs;
using Citizen_Geo_API.Repositories.Interfaces;
using Citizen_Geo_API.Services.Interfaces;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Text.Json;
using Newtonsoft.Json;
using PolygonModel = Citizen_Geo_API.Models.Polygon;
using SystemTextJson = System.Text.Json.JsonSerializer;


namespace Citizen_Geo_API.Services.Implementations
{
    public class PolygonService : IPolygonService
    {
        private readonly IPolygonRepository _repository;
        private readonly GeometryFactory _geometryFactory;
        private readonly GeoJsonReader _geoJsonReader;
        private readonly GeoJsonWriter _geoJsonWriter;

        public PolygonService(IPolygonRepository repository)
        {
            _repository = repository;
            _geometryFactory = new GeometryFactory(new PrecisionModel(), 4326);
            _geoJsonReader = new GeoJsonReader(_geometryFactory, new JsonSerializerSettings());
            _geoJsonWriter = new GeoJsonWriter();
        }

        public async Task<List<PolygonDto>> GetAllAsync()
        {
            var polygons = await _repository.GetAllAsync();
            
            return polygons.Select(p => new PolygonDto
            {
                Id = p.Id,
                Name = p.Name,
                Geometry = SystemTextJson.Deserialize<JsonElement>(_geoJsonWriter.Write(p.Geometry)),
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public async Task<PolygonDto?> CreateAsync(CreatePolygonDto dto)
        {
            // JsonElement-i string-ə çevir
            var geoJsonString = SystemTextJson.Serialize(dto.Geometry);
            
            // Parse GeoJSON
            var feature = _geoJsonReader.Read<Geometry>(geoJsonString);
            
            var polygon = new PolygonModel
            {
                Name = dto.Name,
                Geometry = feature,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repository.CreateAsync(polygon);
            
            return new PolygonDto
            {
                Id = created.Id,
                Name = created.Name,
                Geometry = SystemTextJson.Deserialize<JsonElement>(_geoJsonWriter.Write(created.Geometry)),
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}