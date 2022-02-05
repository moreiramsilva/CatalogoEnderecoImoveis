#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTeste.Data;
using WebApplicationTeste.DTO;
using WebApplicationTeste.Models;
using WebApplicationTeste.Services;
namespace WebApplicationTeste.Controllers
{
    public class CatalogoImovelsController : Controller
    {
        private readonly WebApplicationTesteContext _context;

        public CatalogoImovelsController(WebApplicationTesteContext context)
        {
            _context = context;
        }

        // GET: CatalogoImovels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogoImovel.Include(m => m.Proprietario).ToListAsync());
        }

        // GET: CatalogoImovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoImovel = await _context.CatalogoImovel
                .Include(m => m.Proprietario).FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoImovel == null)
            {
                return NotFound();
            }

            return View(catalogoImovel);
        }

        // GET: CatalogoImovels/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> FindCep(string cep) {
            DadosImovelDTO imovel = await CepService.GetCepAsync(cep);
            if (imovel == null) {
                return View("Create");
            }
            CatalogoImovel catalogoImovel = new CatalogoImovel();
            catalogoImovel.Cep = cep;
            catalogoImovel.Rua = imovel.logradouro;
            catalogoImovel.Complemento = "Bairro: " + imovel.bairro + "|  Cidade: " + imovel.localidade + "|  UF:" + imovel.uf 
                + "|  InfoComplementar: " + imovel.complemento;

            return PartialView("Create", catalogoImovel);
        }

        // POST: CatalogoImovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatalogoImovel Imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Imovel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(Imovel);
        }

        // GET: CatalogoImovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoImovel = await _context.CatalogoImovel
                .Include(m => m.Proprietario).FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoImovel == null)
            {
                return NotFound();
            }
            return View(catalogoImovel);
        }

        // POST: CatalogoImovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CatalogoImovel Imovel)
        {
            if (id != Imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Imovel);
                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoImovelExists(Imovel.Id))
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
            return View(Imovel);
        }

        // GET: CatalogoImovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoImovel = await _context.CatalogoImovel
                .Include(m => m.Proprietario).FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoImovel == null)
            {
                return NotFound();
            }

            return View(catalogoImovel);
        }

        // POST: CatalogoImovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoImovel = await _context.CatalogoImovel.FindAsync(id);
            _context.CatalogoImovel.Remove(catalogoImovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoImovelExists(int id)
        {
            return _context.CatalogoImovel.Any(e => e.Id == id);
        }
    }
}
