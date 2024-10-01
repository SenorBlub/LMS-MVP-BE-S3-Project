namespace Core.Interfaces.IRepositories;

public interface IActivityPlanRepository
{
	Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync();
	Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync(int count);
	Task<IEnumerable<ActivityPlan>> GetPlannedActivitiesAsync(int page, int pageSize);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId, int count);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByActivityAsync(int activityId, int page, int pageSize);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId, int count);
	Task<IEnumerable<ActivityPlan>> GetActivityPlansByPlanAsync(int planId, int page, int pageSize);
	Task CreateActivityPlanAsync(ActivityPlan activityPlan);
	Task DeleteActivityPlanAsync(int id);
}