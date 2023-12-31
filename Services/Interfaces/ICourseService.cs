namespace Escuela.Services;

using Escuela.Data;
using Escuela.Models;

public interface ICourseService {
    EscuelaContext getContext();
    void Create(Course obj);
    List<Course> GetAll(string? filter);
    void Update(Course obj, int id);
    void Delete(Course obj);
    Task<Course?> GetById(int? id);
    List<Student> GetAllStudents();
    void DeleteAllCoursesByStudentId(int? id);
}