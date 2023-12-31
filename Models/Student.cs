namespace Escuela.Models;
using Escuela.Models;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? LastName { get; set; }
    public virtual ICollection<Course>? Courses { get; set; }
}