using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OldMotors.Application.Interfaces;
using OldMotors.Entityes.Entityes;

namespace WebOldMotors.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoApp _produtoApp;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProdutoController(IProdutoApp produtoApp, UserManager<ApplicationUser> userManager)
        {
            _produtoApp = produtoApp;
            _userManager = userManager;
        }

        // GET: ProdutoController
        public async Task<IActionResult> Index()
        {
            var idUsuario = await RetornaIdUsuarioLogado();
            return View(await _produtoApp.ListaProdutoUsuario(idUsuario));
        }

        // GET: ProdutoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _produtoApp.GetById(id));
        }

        // GET: ProdutoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                var idUsuario = await RetornaIdUsuarioLogado();
                produto.UserId = idUsuario;
                await _produtoApp.AddProduto(produto);
                if (produto.Notificacoes.Any())
                {
                    foreach (var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    return View("Create", produto);
                }

            }
            catch
            {
                return View("Create", produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _produtoApp.GetById(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {
                await _produtoApp.UpdateProduto(produto);
                if (produto.Notificacoes.Any())
                {
                    foreach (var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View("Edit", produto);
                }

            }
            catch
            {
                return View("Edit", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Delete/5
            public async Task<IActionResult> Delete(int id)
        {
            return View(await _produtoApp.GetById(id));
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _produtoApp.GetById(id);
                await _produtoApp.Remover(produtoDeletar.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<string> RetornaIdUsuarioLogado()
        {
            var idUsuario = await _userManager.GetUserAsync(User);
            return idUsuario.Id;
        }
    }
}
