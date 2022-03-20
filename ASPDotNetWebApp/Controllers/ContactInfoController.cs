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
    public class ContactInfoController : Controller
    {
        private readonly DotNetCoreMySQLContext _context;

        public ContactInfoController(DotNetCoreMySQLContext context)
        {
            _context = context;
        }

        // GET: ContactInfo
        public async Task<IActionResult> Index()
        {
            var dotNetCoreMySQLContext = _context.ContactInfo.Include(c => c.Student);
            return View(await dotNetCoreMySQLContext.ToListAsync());
        }

        // GET: ContactInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfo
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // GET: ContactInfo/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "ID", "FullName");
            return View();
        }

        // POST: ContactInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,PhoneNumber,StudentID")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "ID", "FullName", contactInfo.StudentID);
            return View(contactInfo);
        }

        // GET: ContactInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfo.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "ID", "FullName", contactInfo.StudentID);
            return View(contactInfo);
        }

        // POST: ContactInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,PhoneNumber,StudentID")] ContactInfo contactInfo)
        {
            if (id != contactInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.ID))
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
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "ID", "FullName", contactInfo.StudentID);
            return View(contactInfo);
        }

        // GET: ContactInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfo
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // POST: ContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfo = await _context.ContactInfo.FindAsync(id);
            _context.ContactInfo.Remove(contactInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfo.Any(e => e.ID == id);
        }
    }
}
