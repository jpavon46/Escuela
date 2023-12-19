namespace Escuela.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Escuela.Data;
using Escuela.Models;

public class StudentService : IStudentService
{

    private readonly EscuelaContext _context;

    public StudentService(EscuelaContext context)
    {
        _context = context;
    }

    public EscuelaContext getContext()
    {
        return _context;
    }

    public void Create(Student obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Student> GetAll(string? filter)
    {
        var query = from Student in _context.Student select Student;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()) || x.Age.ToString().ToLower().Contains(filter.ToLower()));
        }

        return query.ToList();
    }

    public void Update(Student obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Student obj)
    {
        _context.Student.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Student?> GetById(int? id)
    {
        var task = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);

        return task;
    }
}