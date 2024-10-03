using Core.Interfaces.IRepositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ActivityRepository : IActivityRepository
{
	private readonly MvpApiDbContext _context;
	private readonly DbSet<Activity> _dbSet;

	public ActivityRepository(MvpApiDbContext context)
	{
		_context = context;
		_dbSet = context.Activities;
	}

	public async Task<Activity> GetActivityByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()	
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(int count)
	{
		// Retrieve a limited number of Activities
		return await _dbSet.Take(count).ToListAsync();
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(int page, int pageSize)
	{
		return await _dbSet
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task CreateActivityAsync(Activity activity)
	{
		await _dbSet.AddAsync(activity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateActivityAsync(Activity activity)
	{
		_dbSet.Update(activity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteActivityAsync(int id)
	{
		var activity = await _dbSet.FindAsync(id);
		if (activity != null)
		{
			_dbSet.Remove(activity);
			await _context.SaveChangesAsync();
		}
	}
}
