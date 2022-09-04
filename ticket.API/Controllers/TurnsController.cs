using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ticket.API.Data;
using ticket.API.Data.Entities;

namespace ticket.API.Controllers
{
    public class TurnsController : Controller
    {
        private readonly DataContext _context;

        public TurnsController(DataContext context)
        {
            _context = context;
        }

        // GET: Turns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turns.ToListAsync());
        }

        // GET: Turns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }

            return View(turn);
        }

        // GET: Turns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServicesType,ShiftNumber,Date,Time")] Turn turn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turn);
        }

        // GET: Turns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns.FindAsync(id);
            if (turn == null)
            {
                return NotFound();
            }
            return View(turn);
        }

        // POST: Turns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServicesType,ShiftNumber,Date,Time")] Turn turn)
        {
            if (id != turn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnExists(turn.Id))
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
            return View(turn);
        }

        // GET: Turns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }

            return View(turn);
        }

        // POST: Turns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turn = await _context.Turns.FindAsync(id);
            _context.Turns.Remove(turn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnExists(int id)
        {
            return _context.Turns.Any(e => e.Id == id);
        }
    }
}
