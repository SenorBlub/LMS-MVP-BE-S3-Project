using Core.Models;

namespace Core.Interfaces.IRepositories;

public interface IPlanDateRepository
{
	Task<IEnumerable<Plan>> GetDatePlansAsync(DateEntity date);
	Task<DateEntity> GetPlanDateAsync(Plan plan);
	Task CreatePlanDateAsync(PlanDate planDate);
	Task DeletePlanDateAsync(PlanDate planDate);
	Task DeletePlanDateAsync(Plan plan);
	Task DeletePlanDateAsync(DateTime date);
	Task DeletePlanDateAsync(Plan plan, DateTime date);
}