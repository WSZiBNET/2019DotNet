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
    public class TransactionController : Controller
    {
        private readonly DataDbContext _context;

        public TransactionController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Transactions.Include(t => t.AspNetUsers).Include(t => t.Items);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Transactions
                .Include(t => t.AspNetUsers)
                .Include(t => t.Items)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            ViewData["IDuid"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["IDProduct"] = new SelectList(_context.Items, "ID", "ID");
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TimeStamp,IDProduct,Price,Amount,TotalPrice,IDuid")] TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDuid"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", transactionModel.IDuid);
            ViewData["IDProduct"] = new SelectList(_context.Items, "ID", "ID", transactionModel.IDProduct);
            return View(transactionModel);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Transactions.SingleOrDefaultAsync(m => m.ID == id);
            if (transactionModel == null)
            {
                return NotFound();
            }
            ViewData["IDuid"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", transactionModel.IDuid);
            ViewData["IDProduct"] = new SelectList(_context.Items, "ID", "ID", transactionModel.IDProduct);
            return View(transactionModel);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TimeStamp,IDProduct,Price,Amount,TotalPrice,IDuid")] TransactionModel transactionModel)
        {
            if (id != transactionModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionModelExists(transactionModel.ID))
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
            ViewData["IDuid"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", transactionModel.IDuid);
            ViewData["IDProduct"] = new SelectList(_context.Items, "ID", "ID", transactionModel.IDProduct);
            return View(transactionModel);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Transactions
                .Include(t => t.AspNetUsers)
                .Include(t => t.Items)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transactions.SingleOrDefaultAsync(m => m.ID == id);
            _context.Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionModelExists(int id)
        {
            return _context.Transactions.Any(e => e.ID == id);
        }
    }
}
