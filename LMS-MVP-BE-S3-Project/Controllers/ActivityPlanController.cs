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

		[HttpGet("plansByActivity/{activityId}")]
		public async Task<ActionResult<IEnumerable<Plan>>> GetPlansByActivity(int activityId)
		{
			var plans = await _activityPlanService.GetPlansByActivityAsync(new Activity { Id = activityId });
			return Ok(plans);
		}

		[HttpGet("activitiesByPlan/{planId}")]
		public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByPlan(int planId)
		{
			var activities = await _activityPlanService.GetActivitiesByPlanAsync(new Plan { Id = planId });
			return Ok(activities);
		}

		[HttpPost("link")]
		public async Task<ActionResult> LinkActivityToPlan([FromQuery] int activityId, [FromQuery] int planId)
		{
			await _activityPlanService.LinkPlanToActivityAsync(planId, activityId);
			return Ok();
		}
	}
}