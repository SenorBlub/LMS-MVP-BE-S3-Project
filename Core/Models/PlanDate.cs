using Core.Interfaces.IModels;

namespace Core.Models;

public class PlanDate :IPlanDate
{
	public int Id { get; set; }
	public int? PlanId { get; set; }
	public int? DateId { get; set; }
	public Plan Plan { get; set; }
	public DateEntity DateEntity { get; set; }
}