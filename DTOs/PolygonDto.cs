using System.Text.Json.Serialization;
namespace Citizen_Geo_API.DTOs;

public class PolygonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
        
    [JsonPropertyName("geometry")]
    public object Geometry { get; set; } = null!;
        
    public DateTime CreatedAt { get; set; }
}

public class CreatePolygonDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
        
    [JsonPropertyName("geometry")]
    public object Geometry { get; set; } = null!;
}