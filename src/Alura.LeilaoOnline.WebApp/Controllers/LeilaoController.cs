using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {

        IAdminService _service;
        IProdutoService _produtoService;

        public LeilaoController(IAdminService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var leiloes = _service.ConsultaLeiloes();
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _service.CadastraLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _service.ModificaLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            _service.IniciaPregaoDoLeilaoComId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            _service.FinalizaPregaoDoLeilaoComId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _service.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _service.RemoveLeilao(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _service.ConsultaLeiloes()
                .Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
