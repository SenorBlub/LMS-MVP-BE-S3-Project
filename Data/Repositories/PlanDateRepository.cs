using Core.Interfaces.IRepositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PlanDateRepository : IPlanDateRepository
{
	private readonly MvpApiDbContext _context;
	private readonly DbSet<PlanDate> _dbSet;

	public PlanDateRepository(MvpApiDbContext context)
	{
		_context = context;
		_dbSet = context.PlanDates;
	}

	public async Task<IEnumerable<Plan>> GetDatePlansAsync(DateEntity date)
	{
		// Retrieve all plans associated with the given date
		return await _dbSet
			.Where(pd => pd.DateId == date.Id) // Filter PlanDate records by DateEntity ID
			.Include(pd => pd.Plan) // Include Plan details
			.Select(pd => pd.Plan) // Select the associated Plan
			.ToListAsync();
	}

	public async Task<DateEntity> GetPlanDateAsync(Plan plan)
	{
		// Retrieve the DateEntity associated with the given plan
		var planDate = await _dbSet
			.Include(pd => pd.DateEntity) // Include DateEntity details
			.FirstOrDefaultAsync(pd => pd.PlanId == plan.Id); // Filter by Plan ID

		return planDate?.DateEntity; // Return the associated DateEntity (or null if not found)
	}

	public async Task CreatePlanDateAsync(PlanDate planDate)
	{
		// Add a new PlanDate record
		await _dbSet.AddAsync(planDate);
		await _context.SaveChangesAsync();
	}

	public async Task DeletePlanDateAsync(PlanDate planDate)
	{
		// Remove a specific PlanDate record
		_dbSet.Remove(planDate);
		await _context.SaveChangesAsync();
	}

	public async Task DeletePlanDateAsync(Plan plan)
	{
		// Find and delete all PlanDate records associated with the given Plan
		var planDates = _dbSet.Where(pd => pd.PlanId == plan.Id);
		_dbSet.RemoveRange(planDates);
		await _context.SaveChangesAsync();
	}

	public async Task DeletePlanDateAsync(DateTime date)
	{
		// Find and delete all PlanDate records associated with the given DateEntity
		var planDates = _dbSet
			.Include(pd => pd.DateEntity)
			.Where(pd => pd.DateEntity.Date == date);

		_dbSet.RemoveRange(planDates);
		await _context.SaveChangesAsync();
	}

	public async Task DeletePlanDateAsync(Plan plan, DateTime date)
	{
		// Find and delete the PlanDate record associated with the given Plan and DateEntity
		var planDate = await _dbSet
			.Include(pd => pd.DateEntity)
			.FirstOrDefaultAsync(pd => pd.PlanId == plan.Id && pd.DateEntity.Date == date);

		if (planDate != null)
		{
			_dbSet.Remove(planDate);
			await _context.SaveChangesAsync();
		}
	}
}
