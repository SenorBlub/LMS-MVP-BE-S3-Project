using Core.Interfaces.IModels;

namespace Core.Models;

public class Plan : IPlan
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
}