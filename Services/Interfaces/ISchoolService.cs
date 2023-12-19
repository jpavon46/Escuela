namespace Escuela.Services;

using Escuela.Data;
using Escuela.Models;

public interface ISchoolService {
    void Create(School obj);
    List<School> GetAll(string? filter);
    void Update(School obj, int id);
    void Delete(School obj);
    Task<School?> GetById(int? id);
    EscuelaContext getContext();
}