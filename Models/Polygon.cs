using NetTopologySuite.Geometries;

namespace Citizen_Geo_API.Models;

public class Polygon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Geometry Geometry { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}