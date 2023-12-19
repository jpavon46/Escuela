namespace Escuela.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escuela.Models;
using Escuela.Data;
using Microsoft.EntityFrameworkCore;

public class CourseService : ICourseService
{

    private readonly EscuelaContext _context;

    public CourseService(EscuelaContext context)
    {
        _context = context;
    }

    public EscuelaContext getContext()
    {
        return _context;
    }

    public void Create(Course obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Course> GetAll(string? filter)
    {
        if (!string.IsNullOrEmpty(filter))
        {
            return _context.Course
                .Include(a => a.Teacher)
                .Include(a => a.Student)
                .Where(a => a.Description.Contains(filter.ToLower())).ToList();
        }

        return _context.Course
               .Include(a => a.Teacher)
               .Include(a => a.Student).ToList();
    }

    public void Update(Course obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Course school)
    {
        _context.Course.Remove(school);
        _context.SaveChangesAsync();
    }

    public async Task<Course?> GetById(int? id)
    {
        var schoolTask = await _context.Course
                                    .Include(a => a.Teacher)
                                    .Include(a => a.Student)
                                    .FirstOrDefaultAsync(m => m.Id == id);

        return schoolTask;
    }

    public List<Student> GetAllStudents()
    {
        var query = from Student in _context.Student select Student;
        return query.ToList();
    }

    public void DeleteAllCoursesByStudentId(int? id) {
        var courses = GetAll("");

            var filteredCourses = courses.Where(a => a.StudentId == id).ToList();

            _context.RemoveRange(filteredCourses);
            _context.SaveChanges();
    }
}