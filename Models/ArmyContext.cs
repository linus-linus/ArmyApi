#nullable disable
using Microsoft.EntityFrameworkCore;

namespace ArmyAPI.Models;

public class ArmyContext : DbContext
{
public ArmyContext(DbContextOptions<ArmyContext> options):base(options){}

public DbSet<ArmyAPI.Models.Soldier> Soldier { get; set; }

public DbSet<ArmyAPI.Models.Weapon> Weapon { get; set; }

public DbSet<ArmyAPI.Models.Vehicle> Vehicle { get; set; }

}