using Core.Interfaces.IModels;

namespace Core.Models;

public class DateEntity : IDateEntity
{
	public int Id { get; set; }
	public DateTime? Date { get; set; }
}
