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
		_dbSet = context.Set<Activity>(); // Initialize _dbSet with the correct type
	}

	public async Task<Activity> GetActivityByIdAsync(int id)
	{
		// Retrieve a single Activity by its ID
		return await _dbSet.FindAsync(id);
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
	{
		// Retrieve all Activities from the database
		return await _dbSet.ToListAsync();
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(int count)
	{
		// Retrieve a limited number of Activities
		return await _dbSet.Take(count).ToListAsync();
	}

	public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(int page, int pageSize)
	{
		// Implement pagination for Activities
		return await _dbSet
			.Skip((page - 1) * pageSize) // Skip previous pages
			.Take(pageSize) // Retrieve only the required page size
			.ToListAsync();
	}

	public async Task CreateActivityAsync(Activity activity)
	{
		// Add a new Activity to the database
		await _dbSet.AddAsync(activity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateActivityAsync(Activity activity)
	{
		// Update an existing Activity in the database
		_dbSet.Update(activity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteActivityAsync(int id)
	{
		// Find and delete an Activity by its ID
		var activity = await _dbSet.FindAsync(id);
		if (activity != null)
		{
			_dbSet.Remove(activity);
			await _context.SaveChangesAsync();
		}
	}
}
