using Escuela.Models;

namespace Escuela.ViewModels;
public class CourseViewModel
{
    public List<Course>? Courses { get; set; }
    public string? filter { get; set; }
}