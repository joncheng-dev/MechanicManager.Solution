using Microsoft.EntityFrameworkCore;

namespace MechanicManager.Models
{
  public class MechanicManagerContext : DbContext
  {
    public MechanicManagerContext(DbContextOptions options) : base(options) { }
  }
}