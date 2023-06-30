using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;
using RecruitApi.Models.Training;

public interface IAppDbContext
{
  DbSet<User> Users { get; }
  DbSet<Equipment> Equipments { get; }
  DbSet<Exercise> Exercises { get; }

  Task<int> SaveToDbAsync();
}