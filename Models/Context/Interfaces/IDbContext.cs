public interface IDbContext
{
  Task<int> SaveToDbAsync();
}