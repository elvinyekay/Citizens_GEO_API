namespace Citizen_Geo_API.DTOs;

public class CitizenDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Fin { get; set; }  = string.Empty;
    public string SerialNo { get; set; }  = string.Empty;
    public DateTime BirthDate { get; set; }
}