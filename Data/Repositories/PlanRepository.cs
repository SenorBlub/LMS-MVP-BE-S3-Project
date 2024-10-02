using Core.Interfaces.IRepositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PlanRepository : IPlanRepository
{
	private readonly MvpApiDbContext _context;
	private readonly DbSet<Plan> _dbSet;

	public PlanRepository(MvpApiDbContext context)
	{
		_context = context;
		_dbSet = context.Set<Plan>(); // Correctly initialize _dbSet
	}

	public async Task<Plan> GetPlanByIdAsync(int id)
	{
		// Retrieve a single Plan by its ID
		return await _dbSet.FindAsync(id);
	}

	public async Task<IEnumerable<Plan>> GetAllPlansAsync()
	{
		// Retrieve all Plan records from the database
		return await _dbSet.ToListAsync();
	}

	public async Task<IEnumerable<Plan>> GetAllPlansAsync(int count)
	{
		// Retrieve a limited number of Plan records
		return await _dbSet.Take(count).ToListAsync();
	}

	public async Task<IEnumerable<Plan>> GetAllPlansAsync(int page, int pageSize)
	{
		// Implement pagination for Plan records
		return await _dbSet
			.Skip((page - 1) * pageSize) // Skip previous pages
			.Take(pageSize) // Retrieve only the required page size
			.ToListAsync();
	}

	public async Task CreatePlanAsync(Plan plan)
	{
		// Add a new Plan record to the database
		await _dbSet.AddAsync(plan);
		await _context.SaveChangesAsync();
	}

	public async Task UpdatePlanAsync(Plan plan)
	{
		// Update an existing Plan record in the database
		_dbSet.Update(plan);
		await _context.SaveChangesAsync();
	}

	public async Task DeletePlanAsync(int id)
	{
		// Find and delete a Plan by its ID
		var plan = await _dbSet.FindAsync(id);
		if (plan != null)
		{
			_dbSet.Remove(plan);
			await _context.SaveChangesAsync();
		}
	}
}
