using Microsoft.EntityFrameworkCore;
using RecruitApi.Models.Training;

namespace RecruitApi.Models;

public class AppDbContext : DbContext, IAppDbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
  {
  }

  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Exercise> Exercises { get; set; } = null!;
  public DbSet<Equipment> Equipments { get; set; } = null!;

  public async Task<int> SaveToDbAsync()
  {
    return await SaveChangesAsync();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Exercise>()
       .HasOne(e => e.Author)
       .WithMany()
       .HasForeignKey(e => e.AuthorId);

    modelBuilder.Entity<Exercise>()
         .HasMany(e => e.Equipment)
         .WithMany()
         .UsingEntity(join => join.ToTable("ExerciseEquipment"));

    modelBuilder.Entity<User>().ToTable("users_tb");
    modelBuilder.Entity<Equipment>().ToTable("equipments_tb");
    modelBuilder.Entity<Exercise>().ToTable("exercises_tb");
  }
}