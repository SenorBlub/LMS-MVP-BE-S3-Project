using Core.Interfaces.IModels;

namespace Core.Models;

public class ActivityPlan :IActivityPlan
{
	public int Id { get; set; }
	public int ActivityId { get; set; }
	public int PlanId { get; set; }
	public Activity Activity { get; set; }
	public Plan Plan { get; set; }
}