using Core.Interfaces.IModels;

namespace Core.Models;

public class Activity : IActivity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public int? SummerizationId { get; set; }
}