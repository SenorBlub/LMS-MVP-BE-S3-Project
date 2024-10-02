using Core.Models;

namespace Core.Interfaces.IServices;

public interface IActivityService
{
	Task<Activity> GetActivityByIdAsync(int id);
	Task<IEnumerable<Activity>> GetActivitiesAsync();
	Task<IEnumerable<Activity>> GetActivitiesByPlanAsync(Plan plan);
	Task CreateActivityAsync(Activity activity);
	Task UpdateActivityAsync(Activity activity);
	Task DeleteActivityAsync(int id);
}