using Escuela.Models;

namespace Escuela.ViewModels;
public class StudentViewModel
{
    public List<Student>? students { get; set; }
    public string? filter { get; set; }
}