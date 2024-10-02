using Core.Interfaces.IRepositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

public class ActivityPlanRepository : IActivityPlanRepository
{
	private readonly MvpApiDbContext _context;
	private readonly DbSet<ActivityPlan> _dbSet;

	public ActivityPlanRepository(MvpApiDbContext context)
	{
		_context = context;
		_dbSet = context.Set<ActivityPlan>();
	}

	public async Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync(int count)
	{
		return await _dbSet.Take(count).ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync(int page, int pageSize)
	{
		return await _dbSet
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId)
	{
		return await _dbSet
			.Where(ap => ap.ActivityId == activityId)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId, int count)
	{
		return await _dbSet
			.Where(ap => ap.ActivityId == activityId)
			.Take(count)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId, int page, int pageSize)
	{
		return await _dbSet
			.Where(ap => ap.ActivityId == activityId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId)
	{
		return await _dbSet
			.Where(ap => ap.PlanId == planId)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId, int count)
	{
		return await _dbSet
			.Where(ap => ap.PlanId == planId)
			.Take(count)
			.ToListAsync();
	}

	public async Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId, int page, int pageSize)
	{
		return await _dbSet
			.Where(ap => ap.PlanId == planId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task CreateActivityPlanAsync(ActivityPlan activityPlan)
	{
		await _dbSet.AddAsync(activityPlan);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteActivityPlanAsync(int id)
	{
		var activityPlan = await _dbSet.FindAsync(id);
		if (activityPlan != null)
		{
			_dbSet.Remove(activityPlan);
			await _context.SaveChangesAsync();
		}
	}
}
