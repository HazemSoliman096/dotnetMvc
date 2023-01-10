using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Models
{
  public class CompanyContext : DbContext
  {
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

    public DbSet<Information> Information { get; set; }
  }
}