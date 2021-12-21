using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carlos.Models;

namespace Carlos.Controllers
{
    public class ViagemsController : Controller
    {
        private readonly BancodeDados _context;

        public ViagemsController(BancodeDados context)
        {
            _context = context;
        }

        // GET: Viagems
        public async Task<IActionResult> Index()
        {
            var bancodeDados = _context.Viagems.Include(v => v.Cliente);
            return View(await bancodeDados.ToListAsync());
        }

        // GET: Viagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagems
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id_viagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagems/Create
        public IActionResult Create()
        {
            ViewData["ClienteId_cliente"] = new SelectList(_context.Clientes, "Id_cliente", "Nome");
            return View();
        }

        // POST: Viagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_viagem,Destino,Data,Horario,Quantidade,Preco,ClienteId_cliente")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId_cliente"] = new SelectList(_context.Clientes, "Id_cliente", "Nome", viagem.ClienteId_cliente);
            return View(viagem);
        }

        // GET: Viagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagems.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            ViewData["ClienteId_cliente"] = new SelectList(_context.Clientes, "Id_cliente", "Nome", viagem.ClienteId_cliente);
            return View(viagem);
        }

        // POST: Viagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_viagem,Destino,Data,Horario,Quantidade,Preco,ClienteId_cliente")] Viagem viagem)
        {
            if (id != viagem.Id_viagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Id_viagem))
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
            ViewData["ClienteId_cliente"] = new SelectList(_context.Clientes, "Id_cliente", "Nome", viagem.ClienteId_cliente);
            return View(viagem);
        }

        // GET: Viagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagems
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id_viagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagem = await _context.Viagems.FindAsync(id);
            _context.Viagems.Remove(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagems.Any(e => e.Id_viagem == id);
        }
    }
}
