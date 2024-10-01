using Core.Models;

namespace Core.Interfaces.IRepositories;

public interface IActivityRepository
{
	Task<Activity> GetActivityByIdAsync(int id);
	Task<IEnumerable<Activity>> GetAllActivitiesAsync();
	Task<IEnumerable<Activity>> GetAllActivitiesAsync(int count);
	Task<IEnumerable<Activity>> GetAllActivitiesAsync(int page, int pageSize);
	Task CreateActivityAsync(Activity activity);
	Task UpdateActivityAsync(Activity activity);
	Task DeleteActivityAsync(int id);
}