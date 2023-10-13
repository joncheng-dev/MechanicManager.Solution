using Microsoft.EntityFrameworkCore;

namespace MechanicManager.Models
{
  public class MechanicManagerContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachines { get; set; }

    public MechanicManagerContext(DbContextOptions options) : base(options) { }
  }
}