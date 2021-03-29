using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebVeiculosCrud.Data;
using WebVeiculosCrud.Models;

namespace WebVeiculosCrud.Controllers
{
    //Authorize serve que quando estava ultilizando o Identity, ele só autoriza entrar na tela se usuário que estiver logado.
    [Authorize]
    public class VeiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
            _context.LoginUsuarioModel.Add(
                   new LoginUsuarioModel
                   {
                       EmailUsuario = User.Identity.Name,
                       Detalhes = "Entrou na tela de Listagem na tela de Veiculos"
                   });
            _context.SaveChanges();

            return View(await _context.VeiculosModel.ToListAsync());
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculosModel = await _context.VeiculosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculosModel == null)
            {
                return NotFound();
            }

            _context.LoginUsuarioModel.Add(
                   new LoginUsuarioModel
                   {
                       EmailUsuario = User.Identity.Name,
                       Detalhes = string.Concat(" Entrou na tela de Detalhes do veiculo:",
                       veiculosModel.Id, " - ", veiculosModel.Modelo)
                   });
            _context.SaveChanges();

            return View(veiculosModel);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            _context.LoginUsuarioModel.Add(
                new LoginUsuarioModel
                {
                    EmailUsuario = User.Identity.Name,
                    Detalhes = "Logou na tela de Veiculo"
                });
            _context.SaveChanges();

            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] VeiculosModel veiculosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculosModel);
                await _context.SaveChangesAsync();

                _context.LoginUsuarioModel.Add(
                new LoginUsuarioModel
                {
                    EmailUsuario = User.Identity.Name,
                    Detalhes = string.Concat("Cadastrou o Veiculo:", veiculosModel.Modelo,
                    " Data de Cadastro : ", DateTime.Now.ToLongDateString())
                });
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            return View(veiculosModel);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculosModel = await _context.VeiculosModel.FindAsync(id);
            if (veiculosModel == null)
            {
                return NotFound();
            }

            _context.LoginUsuarioModel.Add(
                   new LoginUsuarioModel
                   {
                       EmailUsuario = User.Identity.Name,
                       Detalhes = string.Concat("Tela de Edição do veiculo:", 
                       veiculosModel.Id, " - ", veiculosModel.Modelo)
                   });
            _context.SaveChanges();

            return View(veiculosModel);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] VeiculosModel veiculosModel)
        {
            if (id != veiculosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculosModel);
                    await _context.SaveChangesAsync();

                    _context.LoginUsuarioModel.Add(
                    new LoginUsuarioModel
                     {
                      EmailUsuario = User.Identity.Name,
                      Detalhes = string.Concat("Atualizou o Veiculo:", veiculosModel.Modelo,
                      " Data de Atualização : ", DateTime.Now.ToLongDateString())
                     });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculosModelExists(veiculosModel.Id))
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
            return View(veiculosModel);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculosModel = await _context.VeiculosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculosModel == null)
            {
                return NotFound();
            }

            return View(veiculosModel);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculosModel = await _context.VeiculosModel.FindAsync(id);
            _context.VeiculosModel.Remove(veiculosModel);
            await _context.SaveChangesAsync();

            _context.LoginUsuarioModel.Add(
                   new LoginUsuarioModel
                   {
                       EmailUsuario = User.Identity.Name,
                       Detalhes = string.Concat("Deletou o Veiculo:", veiculosModel.Modelo,
                     " Data de exclusão : ", DateTime.Now.ToLongDateString())
                   });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool VeiculosModelExists(int id)
        {
            return _context.VeiculosModel.Any(e => e.Id == id);
        }
    }
}
