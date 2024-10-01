namespace Core.Interfaces.IModels;

public interface IActivity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public int? SummerizationId { get; set; }
}