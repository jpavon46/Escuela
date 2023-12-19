namespace Escuela.Services;

using Escuela.Data;
using Escuela.Models;

public interface ICourseService {
    void Create(Course obj);
    List<Course> GetAll(string? filter);
    void Update(Course obj, int id);
    void Delete(Course obj);
    Task<Course?> GetById(int? id);
    EscuelaContext getContext();
    List<Student> GetAllStudents();
    void DeleteAllCoursesByStudentId(int? id);
}