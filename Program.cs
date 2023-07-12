using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecruitApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SystemDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ISystemDbContext>(option =>
{
  return option.GetService<SystemDbContext>();
});

builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var serviceProvider = scope.ServiceProvider;
  var databaseInitializer = serviceProvider.GetRequiredService<IDatabaseInitializer>();

  databaseInitializer.Initialize();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
