using Microsoft.EntityFrameworkCore;

namespace BulkyBookVSC;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<Category> Categories { get; set; }
  
}
