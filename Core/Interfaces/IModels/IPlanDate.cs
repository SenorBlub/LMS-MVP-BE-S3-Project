using Core.Models;

namespace Core.Interfaces.IModels;

public interface IPlanDate
{
	public int Id { get; set; }
	public int? PlanId { get; set; }
	public int? DateId { get; set; }
	public Plan Plan { get; set; }
	public DateEntity DateEntity { get; set; }
}