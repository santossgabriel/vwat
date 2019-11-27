using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VWAT.Models;

namespace VWAT.Services
{
  public class AppDbContext : DbContext
  {
    private readonly ILoggerFactory _loggerFactory;
    public DbSet<Comment> Comments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      _loggerFactory = new LoggerFactory();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseLoggerFactory(_loggerFactory);
    }
  }
}