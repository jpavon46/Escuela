namespace Escuela.Models;

public class School
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public List<Teacher>? Teachers { get; set; }
}