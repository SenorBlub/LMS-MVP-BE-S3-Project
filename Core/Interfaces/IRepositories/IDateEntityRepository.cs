using Core.Models;

namespace Core.Interfaces.IRepositories;

public interface IDateEntityRepository
{
	Task<DateEntity> GetDateAsync(DateTime date);
	Task<DateEntity> UpdateDateAsync(DateEntity date);
	Task<DateEntity> DeleteDateAsync(DateTime date);
	Task<DateEntity> CreateDateAsync(DateTime date);
}