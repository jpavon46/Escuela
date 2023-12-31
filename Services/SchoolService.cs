namespace Escuela.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Escuela.Data;
using Escuela.Models;

public class SchoolService : ISchoolService
{
    private readonly EscuelaContext _context;

    public SchoolService(EscuelaContext context)
    {
        _context = context;
    }

    public EscuelaContext getContext()
    {
        return _context;
    }

    public void Create(School obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<School> GetAll(string? filter)
    {

        if (!string.IsNullOrEmpty(filter))
        {
            return _context.School
                .Include(a => a.Teachers)
                .Where(a => a.Name.ToLower().Contains(filter.ToLower()) || a.Address.ToLower().Contains(filter.ToLower())).ToList();
        }

        return _context.School
               .Include(a => a.Teachers).ToList();
    }

    public void Update(School obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(School school)
    {
        _context.School.Remove(school);
        _context.SaveChangesAsync();
    }

    public async Task<School?> GetById(int? id)
    {
        var schoolTask = await _context.School.Include(a => a.Teachers).FirstOrDefaultAsync(m => m.Id == id);

        return schoolTask;
    }
}