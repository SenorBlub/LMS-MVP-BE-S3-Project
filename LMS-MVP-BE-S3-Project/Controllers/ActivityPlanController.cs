using Core.Interfaces.IServices;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivityPlanController : ControllerBase
	{
		private readonly IActivityPlanService _activityPlanService;

		public ActivityPlanController(IActivityPlanService activityPlanService)
		{
			_activityPlanService = activityPlanService;
		}

		[HttpGet("plans-by-activity/{activityId}")]
		public async Task<ActionResult<IEnumerable<Plan>>> GetPlansByActivity(int activityId)
		{
			var plans = await _activityPlanService.GetPlansByActivityAsync(new Activity { Id = activityId });
			return Ok(plans);
		}

		[HttpGet("activities-by-plan/{planId}")]
		public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByPlan(int planId)
		{
			var activities = await _activityPlanService.GetActivitiesByPlanAsync(new Plan { Id = planId });
			return Ok(activities);
		}

		[HttpPost("link")]
		public async Task<ActionResult> LinkActivityToPlan([FromQuery] int activityId, [FromQuery] int planId)
		{
			throw new NotImplementedException();
		}
	}
}