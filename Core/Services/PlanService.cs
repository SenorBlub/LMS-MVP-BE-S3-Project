using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Models;

namespace Core.Services;

public class PlanService : IPlanService
{
	private readonly IPlanRepository _planRepository;
	private readonly IPlanDateRepository _planDateRepository;
	private readonly IActivityPlanRepository _activityPlanRepository;

	public PlanService(
		IPlanRepository planRepository,
		IPlanDateRepository planDateRepository,
		IActivityPlanRepository activityPlanRepository)
	{
		_planRepository = planRepository;
		_planDateRepository = planDateRepository;
		_activityPlanRepository = activityPlanRepository;
	}

	public async Task<Plan> GetPlanByIdAsync(int id)
	{
		return await _planRepository.GetPlanByIdAsync(id);
	}

	public async Task<IEnumerable<Plan>> GetPlansByDateAsync(DateEntity date)
	{
		return await _planDateRepository.GetDatePlansAsync(date);
	}

	public async Task CreatePlanAsync(Plan plan)
	{
		plan.Id = Guid.NewGuid().GetHashCode();
		await _planRepository.CreatePlanAsync(plan);
	}

	public async Task UpdatePlanAsync(Plan plan)
	{
		await _planRepository.UpdatePlanAsync(plan);
	}

	public async Task DeletePlanAsync(Plan plan)
	{
		await _planRepository.DeletePlanAsync(plan.Id);
	}

	public async Task LinkPlanToDateAsync(Plan plan, DateEntity dateEntity)
	{
		// Create a PlanDate to link the plan to a specific date
		var planDate = new PlanDate
		{
			PlanId = plan.Id,
			DateId = dateEntity.Id
		};

		await _planDateRepository.CreatePlanDateAsync(planDate);
	}

	public async Task LinkActivityToPlanAsync(Activity activity, Plan plan)
	{
		// Create an ActivityPlan to link the activity to a specific plan
		var activityPlan = new ActivityPlan
		{
			ActivityId = activity.Id,
			PlanId = plan.Id
		};

		await _activityPlanRepository.CreateActivityPlanAsync(activityPlan);
	}
}