using Core.Models;

namespace Core.Interfaces.IModels;

public interface IActivityPlan
{
	public int Id { get; set; }
	public int ActivityId { get; set; }
	public int PlanId { get; set; }
	public Activity Activity { get; set; }
	public Plan Plan { get; set; }
}