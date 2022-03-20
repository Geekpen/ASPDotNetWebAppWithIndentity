using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPDotNetWebApp.Data;
using ASPDotNetWebApp.Models;

namespace ASPDotNetWebApp.Controllers
{
    public class StudentTeachersController : Controller
    {
        private readonly DotNetCoreMySQLContext _context;

        public StudentTeachersController(DotNetCoreMySQLContext context)
        {
            _context = context;
        }

        // GET: StudentTeachers
        public async Task<IActionResult> Index()
        {
            var dotNetCoreMySQLContext = _context.StudentTeacher.Include(s => s.Student).Include(s => s.Teacher);
            return View(await dotNetCoreMySQLContext.ToListAsync());
        }

        // GET: StudentTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTeacher = await _context.StudentTeacher
                .Include(s => s.Student)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentTeacher == null)
            {
                return NotFound();
            }

            return View(studentTeacher);
        }

        // GET: StudentTeachers/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName");
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "FullName");
            return View();
        }

        // POST: StudentTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StudentID,TeacherID")] StudentTeacher studentTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName", studentTeacher.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "FullName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // GET: StudentTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTeacher = await _context.StudentTeacher.FindAsync(id);
            if (studentTeacher == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName", studentTeacher.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "FullName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // POST: StudentTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudentID,TeacherID")] StudentTeacher studentTeacher)
        {
            if (id != studentTeacher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTeacherExists(studentTeacher.ID))
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
            ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName", studentTeacher.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "FullName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // GET: StudentTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTeacher = await _context.StudentTeacher
                .Include(s => s.Student)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentTeacher == null)
            {
                return NotFound();
            }

            return View(studentTeacher);
        }

        // POST: StudentTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTeacher = await _context.StudentTeacher.FindAsync(id);
            _context.StudentTeacher.Remove(studentTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTeacherExists(int id)
        {
            return _context.StudentTeacher.Any(e => e.ID == id);
        }
    }
}
