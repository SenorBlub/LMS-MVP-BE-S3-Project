using Core.Models;

namespace Core.Interfaces.IServices;

public interface IPlanService
{
	Task<Plan> GetPlanByIdAsync(int id);
	Task<IEnumerable<Plan>> GetPlansByDateAsync(DateEntity date);
	Task CreatePlanAsync(Plan plan);
	Task UpdatePlanAsync(Plan plan);
	Task DeletePlanAsync(Plan plan);
}