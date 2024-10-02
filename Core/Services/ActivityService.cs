using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ActivityService : IActivityService
{
	private readonly IActivityRepository _activityRepository;
	private readonly IActivityPlanRepository _activityPlanRepository;

	public ActivityService(
		IActivityRepository activityRepository,
		IActivityPlanRepository activityPlanRepository)
	{
		_activityRepository = activityRepository;
		_activityPlanRepository = activityPlanRepository;
	}

	public async Task<Activity> GetActivityByIdAsync(int id)
	{
		return await _activityRepository.GetActivityByIdAsync(id);
	}

	public async Task<IEnumerable<Activity>> GetActivitiesAsync()
	{
		return await _activityRepository.GetAllActivitiesAsync();
	}

	public async Task<IEnumerable<Activity>> GetActivitiesByPlanAsync(Plan plan)
	{
		var activityPlans = await _activityPlanRepository.GetActivityPlansByPlanAsync(plan.Id);
		var activities = new List<Activity>();

		foreach (var activityPlan in activityPlans)
		{
			var activity = await _activityRepository.GetActivityByIdAsync(activityPlan.ActivityId);
			if (activity != null)
			{
				activities.Add(activity);
			}
		}
		return activities;
	}

	public async Task CreateActivityAsync(Activity activity)
	{
		await _activityRepository.CreateActivityAsync(activity);
	}

	public async Task UpdateActivityAsync(Activity activity)
	{
		await _activityRepository.UpdateActivityAsync(activity);
	}

	public async Task DeleteActivityAsync(int id)
	{
		await _activityRepository.DeleteActivityAsync(id);
	}
}