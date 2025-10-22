using Citizen_Geo_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Citizen_Geo_API.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<Citizen>  Citizens { get; set; }
}