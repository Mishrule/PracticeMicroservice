using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticeMicroservice.Services.Identity;
using PracticeMicroservice.Services.Identity.DbContext;
using PracticeMicroservice.Services.Identity.Initializer;
using PracticeMicroservice.Services.Identity.Models;

//var builder = WebApplication.CreateBuilder(args);
//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);


//var app = builder.Build();

//IDbInitializer dbInitializer = 

//startup.Configure(app, builder.Environment, dbInitializer);

namespace PracticeMicroservice.Services.Identity
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
  }
}

