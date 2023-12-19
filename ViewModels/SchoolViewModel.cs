using Escuela.Models;

namespace Escuela.ViewModels;
public class SchoolViewModel
{
    public List<School>? Schools { get; set; }
    public string? filter { get; set; }
}