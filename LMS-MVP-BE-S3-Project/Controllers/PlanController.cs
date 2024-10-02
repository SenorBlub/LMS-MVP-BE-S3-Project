using Core.Interfaces.IServices;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly IPlanService _planService;

		public PlanController(IPlanService planService)
		{
			_planService = planService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Plan>> GetPlanById(int id)
		{
			var plan = await _planService.GetPlanByIdAsync(id);
			if (plan == null) return NotFound();
			return Ok(plan);
		}

		[HttpPost]
		public async Task<ActionResult> CreatePlan([FromBody] Plan plan)
		{
			await _planService.CreatePlanAsync(plan);
			return CreatedAtAction(nameof(GetPlanById), new { id = plan.Id }, plan);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdatePlan(int id, [FromBody] Plan plan)
		{
			if (id != plan.Id) return BadRequest("Plan ID mismatch");

			await _planService.UpdatePlanAsync(plan);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePlan(int id)
		{
			await _planService.DeletePlanAsync(new Plan { Id = id });
			return NoContent();
		}

		[HttpGet("by-date")]
		public async Task<ActionResult<IEnumerable<Plan>>> GetPlansByDate([FromQuery] DateTime date)
		{
			var plans = await _planService.GetPlansByDateAsync(new DateEntity { Date = date });
			return Ok(plans);
		}
	}
}