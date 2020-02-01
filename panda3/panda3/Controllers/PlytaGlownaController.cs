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
    public class PlytaGlownaController : Controller
    {
        private readonly KomputerDbContext _context;

        public PlytaGlownaController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: PlytaGlowna
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlytaGlowna.ToListAsync());
        }

        // GET: PlytaGlowna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytaGlownaModel = await _context.PlytaGlowna
                .SingleOrDefaultAsync(m => m.PlytaGlownaId == id);
            if (plytaGlownaModel == null)
            {
                return NotFound();
            }

            return View(plytaGlownaModel);
        }

        // GET: PlytaGlowna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlytaGlowna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlytaGlownaId,Nazwa")] PlytaGlownaModel plytaGlownaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plytaGlownaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plytaGlownaModel);
        }

        // GET: PlytaGlowna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytaGlownaModel = await _context.PlytaGlowna.SingleOrDefaultAsync(m => m.PlytaGlownaId == id);
            if (plytaGlownaModel == null)
            {
                return NotFound();
            }
            return View(plytaGlownaModel);
        }

        // POST: PlytaGlowna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlytaGlownaId,Nazwa")] PlytaGlownaModel plytaGlownaModel)
        {
            if (id != plytaGlownaModel.PlytaGlownaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plytaGlownaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlytaGlownaModelExists(plytaGlownaModel.PlytaGlownaId))
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
            return View(plytaGlownaModel);
        }

        // GET: PlytaGlowna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytaGlownaModel = await _context.PlytaGlowna
                .SingleOrDefaultAsync(m => m.PlytaGlownaId == id);
            if (plytaGlownaModel == null)
            {
                return NotFound();
            }

            return View(plytaGlownaModel);
        }

        // POST: PlytaGlowna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plytaGlownaModel = await _context.PlytaGlowna.SingleOrDefaultAsync(m => m.PlytaGlownaId == id);
            _context.PlytaGlowna.Remove(plytaGlownaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlytaGlownaModelExists(int id)
        {
            return _context.PlytaGlowna.Any(e => e.PlytaGlownaId == id);
        }
    }
}
