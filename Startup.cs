using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VWAT.Models;
using VWAT.Services;

namespace VWAT
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(options =>
      {
        options.LoginPath = "/Home/Index";
        options.LogoutPath = "/Home/Index";
      });

      var connectionString = "Host=127.0.0.1;Port=5432;Pooling=true;Database=vwat;User Id=vwat;Password=123";
      services.AddControllersWithViews()
          .AddRazorRuntimeCompilation();
      services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

      services.AddScoped<CommentService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseCookiePolicy(new CookiePolicyOptions() { HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None });
      app.UseAuthentication();

      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
