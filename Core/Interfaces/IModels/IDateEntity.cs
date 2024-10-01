namespace Core.Interfaces.IModels;

public interface IDateEntity
{
	public int Id { get; set; }
	public DateTime? Date { get; set; }
}