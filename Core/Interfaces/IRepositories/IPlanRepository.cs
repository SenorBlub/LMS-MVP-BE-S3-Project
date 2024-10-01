using Core.Models;

namespace Core.Interfaces.IRepositories;

public interface IPlanRepository
{
	Task<Plan> GetPlanByIdAsync(int id);
	Task<IEnumerable<Plan>> GetAllPlansAsync();
	Task<IEnumerable<Plan>> GetAllPlansAsync(int count);
	Task<IEnumerable<Plan>> GetAllPlansAsync(int page, int pageSize);
	Task CreatePlanAsync(Plan plan);
	Task UpdatePlanAsync(Plan plan);
	Task DeletePlanAsync(int id);
}