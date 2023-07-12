using Microsoft.EntityFrameworkCore;
using RecruitApi.Models.Training;

public interface ITrainingDbContext : IDbContext
{
  DbSet<Equipment> Equipment { get; }
  DbSet<Exercise> Exercises { get; }
  DbSet<WorkoutSession> WorkoutSessions { get; }
  DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; }
  DbSet<WorkoutProgram> WorkoutPrograms { get; }
  DbSet<NutritionPlan> NutritionPlans { get; }
  DbSet<NutritionPlanItem> NutritionPlanItems { get; }
  DbSet<MuscleGroup> MuscleGroups { get; }

}