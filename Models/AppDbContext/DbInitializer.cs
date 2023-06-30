using System;
using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;

public interface IDatabaseInitializer
{
    void Initialize();
}

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly AppDbContext _dbContext;

    public DatabaseInitializer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Initialize()
    {
        try
        {
            // Apply pending migrations
            _dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occurred during migration
            Console.WriteLine($"Error migrating database: {ex.Message}");
        }
    }
}
