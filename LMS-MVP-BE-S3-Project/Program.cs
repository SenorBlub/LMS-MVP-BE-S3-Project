using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MvpApiDbContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("ConnectionString"),
		new MySqlServerVersion(new Version(9, 0, 1))));

// Register Repositories
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IActivityPlanRepository, ActivityPlanRepository>();
builder.Services.AddScoped<IPlanDateRepository, PlanDateRepository>();
builder.Services.AddScoped<IDateEntityRepository, DateEntityRepository>();

// Register Services
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IActivityPlanService, ActivityPlanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
