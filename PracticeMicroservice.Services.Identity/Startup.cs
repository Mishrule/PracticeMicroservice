using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticeMicroservice.Services.Identity.DbContext;
using PracticeMicroservice.Services.Identity.Initializer;
using PracticeMicroservice.Services.Identity.Models;

namespace PracticeMicroservice.Services.Identity
{
  public class Startup
  {
    public IConfiguration configRoot { get; }

    public Startup(IConfiguration configuration)
    {
      configRoot = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configRoot.GetConnectionString("DefaultConnection"))
      );

      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


      var builder = services.AddIdentityServer(options =>
        {
          options.Events.RaiseErrorEvents = true;
          options.Events.RaiseInformationEvents = true;
          options.Events.RaiseFailureEvents = true;
          options.Events.RaiseSuccessEvents = true;
          options.EmitStaticAudienceClaim = true;
        }).AddInMemoryIdentityResources(SD.IdentityResource)
        .AddInMemoryApiScopes(SD.ApiScopes)
        .AddInMemoryClients(SD.Clients)
        .AddAspNetIdentity<ApplicationUser>();

      services.AddScoped<IDbInitializer, DbInitializer>();

      //used in development mode
      builder.AddDeveloperSigningCredential();


      // Add services to the container.
      services.AddControllersWithViews();
      //services.AddRazorPages();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env, IDbInitializer dbInitializer)
    {
      if (!app.Environment.IsDevelopment())
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseIdentityServer();
      app.UseAuthorization();
      dbInitializer.Initialize();
      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

      app.Run();
    }
  }
}

