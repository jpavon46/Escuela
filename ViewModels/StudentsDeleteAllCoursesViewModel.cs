using Escuela.Models;

namespace Escuela.ViewModels;
public class StudentsDeleteAllCoursesViewModel
{
    public int StudentId { get; set; }
    public List<Student>? students { get; set; }
}