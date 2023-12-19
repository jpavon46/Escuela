namespace Escuela.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Escuela.Data;
using Escuela.Models;

public class TeacherService : ITeacherService
{

    private readonly EscuelaContext _context;

    public TeacherService(EscuelaContext context)
    {
        _context = context;
    }

    public EscuelaContext getContext()
    {
        return _context;
    }

    public void Create(Teacher obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Teacher> GetAll(string? filter)
    {
        var query = from Teacher in _context.Teacher select Teacher;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()) 
            || x.Age.ToString().ToLower().Contains(filter.ToLower())
            || x.Specialty.ToLower().Contains(filter.ToLower()));
        }

        var qry = query.Include(x => x.School).ToList();
        return qry;
    }

    public void Update(Teacher obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Teacher obj)
    {
        _context.Teacher.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Teacher?> GetById(int? id)
    {
        var task = await _context.Teacher.Include(x => x.School).FirstOrDefaultAsync(m => m.Id == id);

        return task;
    }
}