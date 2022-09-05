using Microsoft.EntityFrameworkCore;
using PracticeMicroservice.Services.ProductApi.Models;

namespace PracticeMicroservice.Services.ProductApi.DbContexts
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<Product> Proucts { get; set; }
  }
}
