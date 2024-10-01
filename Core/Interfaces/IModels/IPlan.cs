namespace Core.Interfaces.IModels;

public interface IPlan
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
}