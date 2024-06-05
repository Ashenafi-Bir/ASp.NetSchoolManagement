using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class CourseAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseAssignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseAssignments.Include(c => c.Course).Include(c => c.Instructor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssignment = await _context.CourseAssignments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseAssignment == null)
            {
                return NotFound();
            }

            return View(courseAssignment);
        }

        // GET: CourseAssignments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FirstName");
            return View();
        }

        // POST: CourseAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,CourseId")] CourseAssignment courseAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", courseAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FirstName", courseAssignment.InstructorId);
            return View(courseAssignment);
        }

        // GET: CourseAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssignment = await _context.CourseAssignments.FindAsync(id);
            if (courseAssignment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", courseAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FirstName", courseAssignment.InstructorId);
            return View(courseAssignment);
        }

        // POST: CourseAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,CourseId")] CourseAssignment courseAssignment)
        {
            if (id != courseAssignment.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseAssignmentExists(courseAssignment.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", courseAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FirstName", courseAssignment.InstructorId);
            return View(courseAssignment);
        }

        // GET: CourseAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssignment = await _context.CourseAssignments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseAssignment == null)
            {
                return NotFound();
            }

            return View(courseAssignment);
        }

        // POST: CourseAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseAssignment = await _context.CourseAssignments.FindAsync(id);
            if (courseAssignment != null)
            {
                _context.CourseAssignments.Remove(courseAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseAssignmentExists(int id)
        {
            return _context.CourseAssignments.Any(e => e.CourseId == id);
        }
    }
}
