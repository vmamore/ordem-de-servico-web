using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Infra.CrossCutting.MvcFilters;

namespace Tecdisa.OS.Site.UI.Controllers
{
    /*
        GestaoClientes => LT,DE,IN,ED,EX
    */

    [RoutePrefix("clientes")]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        
        [Route("listar-todos")]
        [ClaimsAuthorize("GestaoClientes", "LT")]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _clienteAppService.ObterTodosPaginado(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;

            return View(paged.Lista);
        }
        
        [Route("detalhes/{id:guid}")]
        [ClaimsAuthorize("GestaoClientes", "DE")]
        public ActionResult Details(Guid id)
        {
            ClienteEnderecoViewModel clienteEnderecoViewModel = _clienteAppService.ObterPorId(id);

            ViewBag.Tabelas = new SelectList(RetornaTabelas(), "Value", "Text", clienteEnderecoViewModel.Cliente.Tabela);
            ViewBag.Atividades = new SelectList(RetornaAtividades(), "Value", "Text", clienteEnderecoViewModel.Cliente.Atividade);
            
            return View(clienteEnderecoViewModel);
        }
        
        [Route("criar-novo")]
        [ClaimsAuthorize("GestaoClientes", "IN")]
        public ActionResult Create()
        {
            ViewBag.Tabelas = RetornaTabelas();
            ViewBag.Atividades = RetornaAtividades();

            return View();
        }

        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoClientes", "IN")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("editar/{id:guid}")]
        [ClaimsAuthorize("GestaoClientes", "ED")]
        public ActionResult Edit(Guid id)
        {
            ClienteEnderecoViewModel clienteEnderecoViewModel = _clienteAppService.ObterPorId(id);

            ViewBag.Tabelas = new SelectList(RetornaTabelas(), "Value", "Text", clienteEnderecoViewModel.Cliente.Tabela);
            ViewBag.Atividades = new SelectList(RetornaAtividades(), "Value", "Text", clienteEnderecoViewModel.Cliente.Atividade);

            return View(clienteEnderecoViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoClientes", "ED")]
        public ActionResult Edit(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteEnderecoViewModel);
        }
        
        [Route("deletar/{id:guid}")]
        [ClaimsAuthorize("GestaoClientes", "EX")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);
            return View(clienteViewModel);
        }

        [Route("deletar/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoClientes", "EX")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        private ICollection<SelectListItem> RetornaAtividades()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Distribuidora de Alimentos", Value = "1" },
                new SelectListItem { Text = "Distribuidora de Produtos Veterinários", Value = "2" },
                new SelectListItem { Text = "Distribuidora de Medicamentos" , Value = "3" },
                new SelectListItem { Text = "Outros" , Value = "4" },
            };
        }

        private ICollection<SelectListItem> RetornaTabelas()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Avançado", Value = "1" },
                new SelectListItem { Text = "Intermediário", Value = "2" },
                new SelectListItem { Text = "Básico", Value = "3" }
            };
        }
        
        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose();
        }
    }
}
