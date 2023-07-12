using Microsoft.EntityFrameworkCore;
using RecruitApi.Models.Training;

public class TrainingDbContext : DbContext, ITrainingDbContext
{
  public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
      : base(options)
  {
  }

  public Task<int> SaveToDbAsync()
  {
    throw new NotImplementedException();
  }
  public DbSet<Equipment> Equipment { get; set; }
  public DbSet<Exercise> Exercises { get; set; }
  public DbSet<WorkoutSession> WorkoutSessions { get; set; }
  public DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }
  public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
  public DbSet<NutritionPlan> NutritionPlans { get; set; }
  public DbSet<NutritionPlanItem> NutritionPlanItems { get; set; }
  public DbSet<MuscleGroup> MuscleGroups { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Configure the relationship between WorkoutProgram and WorkoutSession
    modelBuilder.Entity<WorkoutProgram>()
        .HasMany(wp => wp.WorkoutSessions)
        .WithOne(ws => ws.WorkoutProgram)
        .HasForeignKey(ws => ws.ProgramId);

    // Configure the relationship between WorkoutSession and WorkoutSessionExercise
    modelBuilder.Entity<WorkoutSession>()
        .HasMany(ws => ws.WorkoutSessionExercises)
        .WithOne(wse => wse.WorkoutSession)
        .HasForeignKey(wse => wse.SessionId);

    // Configure the relationship between Exercise and WorkoutSessionExercise
    modelBuilder.Entity<Exercise>()
        .HasMany(e => e.WorkoutSessionExercises)
        .WithOne(wse => wse.Exercise)
        .HasForeignKey(wse => wse.ExerciseId);

    // Configure the relationship between WorkoutSessionExercise and Equipment
  }

}
