namespace Escuela.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
}