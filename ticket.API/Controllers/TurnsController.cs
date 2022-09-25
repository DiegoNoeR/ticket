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

            var turn = await _context.Turns.FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }

            return View(turn);
        }

        public async Task<IActionResult> Create(int? Type)
        {
            if (Type == 1)
            {               
                var ST = "CA";
                var turn = await _context.Turns.OrderByDescending(x => x.Id).FirstOrDefaultAsync(m => m.ServicesType == ST);
                if (turn == null)
                {
                    var SN = 1;
                    var datenow = DateTime.Now;                   
                    _context.Turns.Add(new Turn { ServicesType = "CA", ShiftNumber = SN, ExpeditionDate = datenow });
                }
                else
                {
                    var SN = turn.ShiftNumber + 1;
                    var datenow = DateTime.Now;
                    _context.Turns.Add(new Turn { ServicesType = "CA", ShiftNumber = SN, ExpeditionDate = datenow });
                }
                
                

                await _context.SaveChangesAsync();
            }

            if (Type == 2)
            {
                var ST = "CI";
                var turn = await _context.Turns.OrderByDescending(x => x.Id).FirstOrDefaultAsync(m => m.ServicesType == ST);
                if (turn == null)
                {
                    var SN = 1;
                    var datenow = DateTime.Now;                    
                    _context.Turns.Add(new Turn { ServicesType = "CI", ShiftNumber = SN, ExpeditionDate = datenow });
                }
                else
                {
                    var SN = turn.ShiftNumber + 1;
                    var datenow = DateTime.Now;
                    _context.Turns.Add(new Turn { ServicesType = "CI", ShiftNumber = SN, ExpeditionDate = datenow });
                }
              

                await _context.SaveChangesAsync();
            }

            if (Type == 3)
            {
                var ST = "ER";
                var turn = await _context.Turns.OrderByDescending(x => x.Id).FirstOrDefaultAsync(m => m.ServicesType == ST);
                if (turn == null)
                {
                    var SN = 1;
                    var datenow = DateTime.Now;
                    _context.Turns.Add(new Turn { ServicesType = "ER", ShiftNumber = SN, ExpeditionDate = datenow });
                }
                else
                {
                    var SN = turn.ShiftNumber + 1;
                    var datenow = DateTime.Now;
                    _context.Turns.Add(new Turn { ServicesType = "ER", ShiftNumber = SN, ExpeditionDate = datenow });
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
       
        // GET: Turns/Edit/5
        public async Task<IActionResult> Edit(int? Type)
        {
            if (Type == 1)
            {
                string ST = "CA";
                Turn turn = await _context.Turns.FirstOrDefaultAsync(m => m.ServicesType == ST && m.Stand == null);
                if (turn == null)
                {
                    return NotFound();
                }

                else
                {
                    turn.Stand = "C-1";
                    turn.AttentionDate = DateTime.Now;

                    _context.Turns.Update(turn);

                   await _context.SaveChangesAsync();
                }
            }

            if (Type == 2)
            {
                string ST = "CI";
                Turn turn = await _context.Turns.FirstOrDefaultAsync(m => m.ServicesType == ST && m.Stand == null);
                if (turn == null)
                {
                    return NotFound();
                }

                else
                {
                    turn.Stand = "V-1";
                    turn.AttentionDate = DateTime.Now;

                    _context.Turns.Update(turn);

                    await _context.SaveChangesAsync();
                }
            }

            if (Type == 3)
            {
                string ST = "ER";
                Turn turn = await _context.Turns.FirstOrDefaultAsync(m => m.ServicesType == ST && m.Stand == null);
                if (turn == null)
                {
                    return NotFound();
                }

                else
                {
                    turn.Stand = "E-1";
                    turn.AttentionDate = DateTime.Now;

                    _context.Turns.Update(turn);

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Turns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*
        public async Task<IActionResult> Edit(int id, Turn turn)
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
        */
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
