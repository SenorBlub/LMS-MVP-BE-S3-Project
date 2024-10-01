using Core.Models;
using Microsoft.EntityFrameworkCore;
using Activity = System.Diagnostics.Activity;

namespace Data.Contexts;

public class MvpApiDbContext : DbContext
{
	public MvpApiDbContext(DbContextOptions<MvpApiDbContext> options)
		: base(options)
	{
	}

	// Define DbSets for each table
	public DbSet<Core.Models.Activity> Activities { get; set; }
	public DbSet<ActivityPlan> ActivityPlans { get; set; }
	public DbSet<DateEntity> Dates { get; set; }
	public DbSet<Plan> Plans { get; set; }
	public DbSet<PlanDate> PlanDates { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Define keys and relationships as specified in the schema

		modelBuilder.Entity<Activity>()
			.HasKey(a => a.Id);

		modelBuilder.Entity<ActivityPlan>()
			.HasKey(ap => ap.Id);

		modelBuilder.Entity<ActivityPlan>()
			.HasOne(ap => ap.Activity)
			.WithMany()
			.HasForeignKey(ap => ap.ActivityId);

		modelBuilder.Entity<ActivityPlan>()
			.HasOne(ap => ap.Plan)
			.WithMany()
			.HasForeignKey(ap => ap.PlanId);

		modelBuilder.Entity<DateEntity>()
			.HasKey(d => d.Id);

		modelBuilder.Entity<Plan>()
			.HasKey(p => p.Id);

		modelBuilder.Entity<PlanDate>()
			.HasKey(pd => pd.Id);

		modelBuilder.Entity<PlanDate>()
			.HasOne(pd => pd.Plan)
			.WithMany()
			.HasForeignKey(pd => pd.PlanId);

		modelBuilder.Entity<PlanDate>()
			.HasOne(pd => pd.DateEntity)
			.WithMany()
			.HasForeignKey(pd => pd.DateId);
	}
}