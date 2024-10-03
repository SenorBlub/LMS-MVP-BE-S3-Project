using Core.Interfaces.IModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Activity : IActivity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	[Column("summerization_id")]
	public int? SummerizationId { get; set; }
}