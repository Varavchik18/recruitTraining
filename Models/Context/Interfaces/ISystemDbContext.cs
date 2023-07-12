using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;

public interface ISystemDbContext : IDbContext
{
  DbSet<User> Users { get; }
  DbSet<Progress> Progresses { get; }
}