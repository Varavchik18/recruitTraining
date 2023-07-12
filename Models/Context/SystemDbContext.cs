using Microsoft.EntityFrameworkCore;

namespace RecruitApi.Models;

public class SystemDbContext : DbContext, ISystemDbContext
{
  public SystemDbContext(DbContextOptions<SystemDbContext> options)
      : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Progress> Progresses { get; set; }

  public async Task<int> SaveToDbAsync()
  {
    return await SaveChangesAsync();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Configure the relationships
    modelBuilder.Entity<Progress>()
        .HasOne(p => p.User)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Progress>()
        .HasOne(p => p.Exercise)
        .WithMany()
        .HasForeignKey(p => p.ExerciseId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
