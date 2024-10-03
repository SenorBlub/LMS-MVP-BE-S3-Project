using Core.Interfaces.IRepositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class DateEntityRepository : IDateEntityRepository
{
	private readonly MvpApiDbContext _context;
	private readonly DbSet<DateEntity> _dbSet;

	public DateEntityRepository(MvpApiDbContext context)
	{
		_context = context;
		_dbSet = context.Dates;
	}

	public async Task<DateEntity> GetDateAsync(DateTime date)
	{
		// Retrieve the DateEntity that matches the specified date
		return await _dbSet.FirstOrDefaultAsync(d => d.Date == date);
	}

	public async Task<DateEntity> CreateDateAsync(DateTime date)
	{
		// Check if the date already exists to prevent duplicates
		var existingDate = await GetDateAsync(date);
		if (existingDate != null)
		{
			// If date exists, return the existing entity
			return existingDate;
		}

		// Create a new DateEntity
		var newDateEntity = new DateEntity { Date = date };
		await _dbSet.AddAsync(newDateEntity);
		await _context.SaveChangesAsync();

		return newDateEntity;
	}

	public async Task<DateEntity> UpdateDateAsync(DateEntity dateEntity)
	{
		// Update the existing DateEntity
		_dbSet.Update(dateEntity);
		await _context.SaveChangesAsync();
		return dateEntity;
	}

	public async Task<DateEntity> DeleteDateAsync(DateTime date)
	{
		// Find the DateEntity by date
		var dateEntity = await GetDateAsync(date);
		if (dateEntity != null)
		{
			_dbSet.Remove(dateEntity);
			await _context.SaveChangesAsync();
		}

		return dateEntity;
	}
}