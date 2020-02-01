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
    public class RezerwacjaNOwiesController : Controller
    {
        private readonly KomputerDbContext _context;

        public RezerwacjaNOwiesController(KomputerDbContext context)
        {
            _context = context;
        }

        // GET: RezerwacjaNOwies
        public async Task<IActionResult> Index()
        {
            return View(await _context.RezerwacjaModelNOwy.ToListAsync());
        }

        // GET: RezerwacjaNOwies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModelNOwy = await _context.RezerwacjaModelNOwy
                .SingleOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacjaModelNOwy == null)
            {
                return NotFound();
            }

            return View(rezerwacjaModelNOwy);
        }

        // GET: RezerwacjaNOwies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RezerwacjaNOwies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezerwacjaID,KomputerID,UzytkownikID,DataRozpoczecia,DataZakonczenia,DataPrzedluzona,Zarezerwowany,Wypozyczony")] RezerwacjaModelNOwy rezerwacjaModelNOwy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacjaModelNOwy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezerwacjaModelNOwy);
        }

        // GET: RezerwacjaNOwies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModelNOwy = await _context.RezerwacjaModelNOwy.SingleOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacjaModelNOwy == null)
            {
                return NotFound();
            }
            return View(rezerwacjaModelNOwy);
        }

        // POST: RezerwacjaNOwies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezerwacjaID,KomputerID,UzytkownikID,DataRozpoczecia,DataZakonczenia,DataPrzedluzona,Zarezerwowany,Wypozyczony")] RezerwacjaModelNOwy rezerwacjaModelNOwy)
        {
            if (id != rezerwacjaModelNOwy.RezerwacjaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacjaModelNOwy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaModelNOwyExists(rezerwacjaModelNOwy.RezerwacjaID))
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
            return View(rezerwacjaModelNOwy);
        }

        // GET: RezerwacjaNOwies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModelNOwy = await _context.RezerwacjaModelNOwy
                .SingleOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacjaModelNOwy == null)
            {
                return NotFound();
            }

            return View(rezerwacjaModelNOwy);
        }

        // POST: RezerwacjaNOwies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacjaModelNOwy = await _context.RezerwacjaModelNOwy.SingleOrDefaultAsync(m => m.RezerwacjaID == id);
            _context.RezerwacjaModelNOwy.Remove(rezerwacjaModelNOwy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaModelNOwyExists(int id)
        {
            return _context.RezerwacjaModelNOwy.Any(e => e.RezerwacjaID == id);
        }
    }
}
