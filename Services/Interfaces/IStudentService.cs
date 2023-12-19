namespace Escuela.Services;
using Escuela.Models;
using Microsoft.EntityFrameworkCore;
using Escuela.Data;

public interface IStudentService {
    void Create(Student obj);
    List<Student> GetAll(string? filter);
    void Update(Student obj, int id);
    void Delete(Student obj);
    Task<Student?> GetById(int? id);
    EscuelaContext getContext();
}