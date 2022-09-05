using Microsoft.EntityFrameworkCore;

namespace PracticeMicroservice.Service.ProductApi.DbContexts
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
  }
}
