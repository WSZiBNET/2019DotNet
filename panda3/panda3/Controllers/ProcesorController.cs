using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panda3.Data;
using panda3.Models;

namespace panda3.Controllers
{
    public class ProcesorController : Controller
    {
        private readonly KomputerDbContext _context;

        public ProcesorController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: Procesor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procesor.ToListAsync());
        }

        // GET: Procesor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesorModel = await _context.Procesor
                .SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (procesorModel == null)
            {
                return NotFound();
            }

            return View(procesorModel);
        }

        // GET: Procesor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procesor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcesorID,Nazwa")] ProcesorModel procesorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesorModel);
        }

        // GET: Procesor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesorModel = await _context.Procesor.SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (procesorModel == null)
            {
                return NotFound();
            }
            return View(procesorModel);
        }

        // POST: Procesor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcesorID,Nazwa")] ProcesorModel procesorModel)
        {
            if (id != procesorModel.ProcesorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesorModelExists(procesorModel.ProcesorID))
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
            return View(procesorModel);
        }

        // GET: Procesor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesorModel = await _context.Procesor
                .SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (procesorModel == null)
            {
                return NotFound();
            }

            return View(procesorModel);
        }

        // POST: Procesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesorModel = await _context.Procesor.SingleOrDefaultAsync(m => m.ProcesorID == id);
            _context.Procesor.Remove(procesorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesorModelExists(int id)
        {
            return _context.Procesor.Any(e => e.ProcesorID == id);
        }
    }
}
