using Escuela.Models;
namespace Escuela.ViewModels;
public class TeacherViewModel
{
    public List<Teacher>? Teachers { get; set; }
    public string? filter { get; set; }
}