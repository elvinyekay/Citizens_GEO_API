using Citizen_Geo_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Citizen_Geo_API.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<Citizen>  Citizens { get; set; }
    public DbSet<Polygon> Polygons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Polygon>(entity =>
        {
            entity.ToTable("Polygons");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Geometry).HasColumnType("geometry(Polygon, 4326)").IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
        });
    }
}