using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirmaBel.Data;
using FirmaBel.Models;

namespace FirmaBel.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDepartment
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDepartments.ToListAsync());
        }

        // GET: EmployeeDepartment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartmentModel = await _context.EmployeeDepartments
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employeeDepartmentModel == null)
            {
                return NotFound();
            }

            return View(employeeDepartmentModel);
        }

        // GET: EmployeeDepartment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DepartmentName")] EmployeeDepartmentModel employeeDepartmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDepartmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDepartmentModel);
        }

        // GET: EmployeeDepartment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartmentModel = await _context.EmployeeDepartments.SingleOrDefaultAsync(m => m.ID == id);
            if (employeeDepartmentModel == null)
            {
                return NotFound();
            }
            return View(employeeDepartmentModel);
        }

        // POST: EmployeeDepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DepartmentName")] EmployeeDepartmentModel employeeDepartmentModel)
        {
            if (id != employeeDepartmentModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDepartmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDepartmentModelExists(employeeDepartmentModel.ID))
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
            return View(employeeDepartmentModel);
        }

        // GET: EmployeeDepartment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartmentModel = await _context.EmployeeDepartments
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employeeDepartmentModel == null)
            {
                return NotFound();
            }

            return View(employeeDepartmentModel);
        }

        // POST: EmployeeDepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDepartmentModel = await _context.EmployeeDepartments.SingleOrDefaultAsync(m => m.ID == id);
            _context.EmployeeDepartments.Remove(employeeDepartmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDepartmentModelExists(int id)
        {
            return _context.EmployeeDepartments.Any(e => e.ID == id);
        }
    }
}
