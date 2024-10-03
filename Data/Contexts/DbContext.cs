using Core.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace Data.Contexts;

public class MvpApiDbContext : DbContext
{
	public MvpApiDbContext(DbContextOptions<MvpApiDbContext> options)
		: base(options)
	{
	}

	// Define DbSets for each table
	public DbSet<Activity> Activities { get; set; }
	public DbSet<ActivityPlan> ActivityPlans { get; set; }
	public DbSet<DateEntity> Dates { get; set; }
	public DbSet<Plan> Plans { get; set; }
	public DbSet<PlanDate> PlanDates { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.UseCollation("utf8mb4_0900_ai_ci");

		modelBuilder.Entity<Activity>()
			.ToTable("activity")
			.HasKey(a => a.Id);

		modelBuilder.Entity<Activity>()
			.Property(a => a.SummerizationId)
			.HasColumnName("summerization_id");
		
		modelBuilder.Entity<ActivityPlan>()
			.ToTable("plan_activity")
			.HasKey(ap => ap.Id);

		modelBuilder.Entity<ActivityPlan>()
			.Property(ap => ap.ActivityId)
			.HasColumnName("activity_id");

		modelBuilder.Entity<ActivityPlan>()
			.Property(ap => ap.PlanId)
			.HasColumnName("plan_id");

		modelBuilder.Entity<ActivityPlan>()
			.ToTable("plan_activity")
			.HasOne(ap => ap.Activity)
			.WithMany()
			.HasForeignKey(ap => ap.ActivityId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<ActivityPlan>()
			.ToTable("activity_plan")
			.HasOne(ap => ap.Plan)
			.WithMany() 
			.HasForeignKey(ap => ap.PlanId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<DateEntity>()
			.ToTable("date")
			.HasKey(d => d.Id);

		modelBuilder.Entity<Plan>()
			.ToTable("plan")
			.HasKey(p => p.Id);

		modelBuilder.Entity<PlanDate>()
			.ToTable("plan_date")
			.HasKey(pd => pd.Id);

		modelBuilder.Entity<PlanDate>()
			.Property(pd => pd.PlanId)
			.HasColumnName("plan_id");

		modelBuilder.Entity<PlanDate>()
			.Property(pd => pd.DateId)
			.HasColumnName("date_id");

		modelBuilder.Entity<PlanDate>()
			.ToTable("plan_date")
			.HasOne(pd => pd.Plan)
			.WithMany() 
			.HasForeignKey(pd => pd.PlanId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<PlanDate>()
			.ToTable("plan_date")
			.HasOne(pd => pd.DateEntity)
			.WithMany() 
			.HasForeignKey(pd => pd.DateId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
