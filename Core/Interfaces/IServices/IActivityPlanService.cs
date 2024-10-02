using Core.Models;

namespace Core.Interfaces.IServices;

public interface IActivityPlanService
{
	Task<IEnumerable<Plan>> GetPlansByActivityAsync(Activity activity);
	Task<IEnumerable<Activity>> GetActivitiesByPlanAsync(Plan plan);
}