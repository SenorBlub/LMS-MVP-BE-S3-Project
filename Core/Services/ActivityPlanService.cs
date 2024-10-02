using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ActivityPlanService : IActivityPlanService
{
	private readonly IActivityPlanRepository _activityPlanRepository;
	private readonly IActivityRepository _activityRepository;
	private readonly IPlanRepository _planRepository;

	public ActivityPlanService(
		IActivityPlanRepository activityPlanRepository,
		IActivityRepository activityRepository,
		IPlanRepository planRepository)
	{
		_activityPlanRepository = activityPlanRepository;
		_activityRepository = activityRepository;
		_planRepository = planRepository;
	}

	public async Task<IEnumerable<Plan>> GetPlansByActivityAsync(Activity activity)
	{
		var activityPlans = await _activityPlanRepository.GetActivityPlansByActivityAsync(activity.Id);
		var plans = new List<Plan>();

		foreach (var activityPlan in activityPlans)
		{
			var plan = await _planRepository.GetPlanByIdAsync(activityPlan.PlanId);
			if (plan != null)
			{
				plans.Add(plan);
			}
		}
		return plans;
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
}