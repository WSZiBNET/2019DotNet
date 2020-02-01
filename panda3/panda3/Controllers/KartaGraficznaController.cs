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
    public class KartaGraficznaController : Controller
    {
        private readonly KomputerDbContext _context;

        public KartaGraficznaController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: KartaGraficzna
        public async Task<IActionResult> Index()
        {
            return View(await _context.KartaGraficzna.ToListAsync());
        }

        // GET: KartaGraficzna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartaGraficznaModel = await _context.KartaGraficzna
                .SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (kartaGraficznaModel == null)
            {
                return NotFound();
            }

            return View(kartaGraficznaModel);
        }

        // GET: KartaGraficzna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KartaGraficzna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcesorID,Nazwa")] KartaGraficznaModel kartaGraficznaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kartaGraficznaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kartaGraficznaModel);
        }

        // GET: KartaGraficzna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartaGraficznaModel = await _context.KartaGraficzna.SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (kartaGraficznaModel == null)
            {
                return NotFound();
            }
            return View(kartaGraficznaModel);
        }

        // POST: KartaGraficzna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcesorID,Nazwa")] KartaGraficznaModel kartaGraficznaModel)
        {
            if (id != kartaGraficznaModel.ProcesorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kartaGraficznaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartaGraficznaModelExists(kartaGraficznaModel.ProcesorID))
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
            return View(kartaGraficznaModel);
        }

        // GET: KartaGraficzna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartaGraficznaModel = await _context.KartaGraficzna
                .SingleOrDefaultAsync(m => m.ProcesorID == id);
            if (kartaGraficznaModel == null)
            {
                return NotFound();
            }

            return View(kartaGraficznaModel);
        }

        // POST: KartaGraficzna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kartaGraficznaModel = await _context.KartaGraficzna.SingleOrDefaultAsync(m => m.ProcesorID == id);
            _context.KartaGraficzna.Remove(kartaGraficznaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartaGraficznaModelExists(int id)
        {
            return _context.KartaGraficzna.Any(e => e.ProcesorID == id);
        }
    }
}
