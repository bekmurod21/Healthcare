using HealthCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Data.Context;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "Server=localhost; Database=HealthCare; User Id=postgres; password=Bekmurod21";
        optionsBuilder.UseNpgsql(path);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<FoodPower> FoodPower { get; set; }
}
