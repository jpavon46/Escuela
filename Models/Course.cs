namespace Escuela.Models;

public class Course
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } 
}