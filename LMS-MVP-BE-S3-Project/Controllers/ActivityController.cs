using Core.Interfaces.IServices;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivityController : ControllerBase
	{
		private readonly IActivityService _activityService;

		public ActivityController(IActivityService activityService)
		{
			_activityService = activityService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Activity>> GetActivityById(int id)
		{
			var activity = await _activityService.GetActivityByIdAsync(id);
			if (activity == null) return NotFound();
			return Ok(activity);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities()
		{
			var activities = await _activityService.GetActivitiesAsync();
			return Ok(activities);
		}

		[HttpPost]
		public async Task<ActionResult> CreateActivity([FromBody] Activity activity)
		{
			await _activityService.CreateActivityAsync(activity);
			return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateActivity(int id, [FromBody] Activity activity)
		{
			if (id != activity.Id) return BadRequest("Activity ID mismatch");

			await _activityService.UpdateActivityAsync(activity);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteActivity(int id)
		{
			await _activityService.DeleteActivityAsync(id);
			return NoContent();
		}

		[HttpGet("by-plan/{planId}")]
		public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByPlan(int planId)
		{
			var activities = await _activityService.GetActivitiesByPlanAsync(new Plan { Id = planId });
			return Ok(activities);
		}
	}
}
