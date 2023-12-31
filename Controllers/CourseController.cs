using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela.Data;
using Escuela.Models;
using Escuela.Services;
using Microsoft.AspNetCore.Authorization;
using Escuela.ViewModels;

namespace Escuela.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        [Authorize]
        public async Task<IActionResult> Index(string? filter)
        {
            var courses = _courseService.GetAll(filter);

            var viewModel = new CourseViewModel();
            viewModel.Courses = courses;

            return View(viewModel);
        }

        // GET: Course/Details/5
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Details(int? id)
        {
            var courseDetail = await _courseService.GetById(id);
            return View(courseDetail);
        }

        // GET: Course/Create
        [Authorize(Roles = "senior,semisenior")]
        public IActionResult Create()
        {
            var availableTeachers = _courseService.getContext().Teacher.Where(d => d.IsAvailable);
            ViewData["TeacherId"] = new SelectList(availableTeachers, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_courseService.getContext().Student, "Id", "Id");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior,semisenior")]
        public async Task<IActionResult> Create([Bind("Id,Description,TeacherId,StudentId")] Course course)
        {
            _courseService.Create(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Course/Edit/5
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _courseService.getContext().Course == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
             var availableTeachers = _courseService.getContext().Teacher.Where(d => d.IsAvailable);
            ViewData["TeacherId"] = new SelectList(availableTeachers, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_courseService.getContext().Student, "Id", "Name", course.StudentId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,TeacherId,StudentId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            _courseService.Update(course,id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _courseService.getContext().Course == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_courseService.getContext().Course == null)
            {
                return Problem("Entity set 'EscuelaContext.Course'  is null.");
            }

            var course = await _courseService.GetById(id);
            if (course != null)
            {
                _courseService.Delete(course);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return (_courseService.getContext().Course?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Authorize(Roles = "senior")]
        public IActionResult DeleteAllStudentCourses() {

            ViewData["StudentId"] = new SelectList(_courseService.getContext().Student.Where(a => a.Courses.Count != 0), "Id", "Name");

            return View();
        }
    }
}
