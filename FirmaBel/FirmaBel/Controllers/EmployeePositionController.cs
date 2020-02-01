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
    public class EmployeePositionController : Controller
    {
        private readonly DataDbContext _context;

        public EmployeePositionController(DataDbContext context)
        {
            _context = context;
        }

        // GET: EmployeePosition
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeePositions.ToListAsync());
        }

        // GET: EmployeePosition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePositionModel = await _context.EmployeePositions
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employeePositionModel == null)
            {
                return NotFound();
            }

            return View(employeePositionModel);
        }

        // GET: EmployeePosition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeePosition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PositionName")] EmployeePositionModel employeePositionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePositionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePositionModel);
        }

        // GET: EmployeePosition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePositionModel = await _context.EmployeePositions.SingleOrDefaultAsync(m => m.ID == id);
            if (employeePositionModel == null)
            {
                return NotFound();
            }
            return View(employeePositionModel);
        }

        // POST: EmployeePosition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PositionName")] EmployeePositionModel employeePositionModel)
        {
            if (id != employeePositionModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePositionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePositionModelExists(employeePositionModel.ID))
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
            return View(employeePositionModel);
        }

        // GET: EmployeePosition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePositionModel = await _context.EmployeePositions
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employeePositionModel == null)
            {
                return NotFound();
            }

            return View(employeePositionModel);
        }

        // POST: EmployeePosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeePositionModel = await _context.EmployeePositions.SingleOrDefaultAsync(m => m.ID == id);
            _context.EmployeePositions.Remove(employeePositionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePositionModelExists(int id)
        {
            return _context.EmployeePositions.Any(e => e.ID == id);
        }
    }
}
