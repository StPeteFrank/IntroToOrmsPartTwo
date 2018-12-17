using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntroToOrmsPartTwo
{
  public partial class VacationSafariContext : DbContext
  {
    public VacationSafariContext()
    {
    }

    public VacationSafariContext(DbContextOptions<VacationSafariContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=VacationSafari");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
    }

    public DbSet<SeenAnimals> SeenAnimals { get; set; }
  }
}
