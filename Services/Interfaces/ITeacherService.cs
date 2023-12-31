namespace Escuela.Services;
using Escuela.Models;
using Microsoft.EntityFrameworkCore;
using Escuela.Data;

public interface ITeacherService {
    EscuelaContext getContext();
    void Create(Teacher obj);
    List<Teacher> GetAll(string? filter);
    void Update(Teacher obj, int id);
    void Delete(Teacher obj);
    Task<Teacher?> GetById(int? id);
}