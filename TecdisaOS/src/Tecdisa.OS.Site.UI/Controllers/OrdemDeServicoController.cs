using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Infra.CrossCutting.MvcFilters;

namespace Tecdisa.OS.Site.UI.Controllers
{
    /*
        GestaoOs => LT,DE,IN,ED,EX
    */

    [RoutePrefix("ordem-de-servico")]
    public class OrdemDeServicoController : BaseController
    {
        private readonly IOrdemDeServicoAppService _osAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly ISistemaAppService _sistemaAppService;
        private readonly IModuloAppService _moduloAppService;
        private readonly IProgramadorAppService _programadorAppService;
        
        public OrdemDeServicoController(IOrdemDeServicoAppService osAppService, IClienteAppService clienteAppService, 
            ISistemaAppService sistemaAppService, IModuloAppService moduloAppService, IProgramadorAppService programadorAppService)
        {
            _osAppService = osAppService;
            _clienteAppService = clienteAppService;
            _sistemaAppService = sistemaAppService;
            _moduloAppService = moduloAppService;
            _programadorAppService = programadorAppService;
        }
        
        [Route("todos")]
        [ClaimsAuthorize("GestaoOs", "LT")]
        public ActionResult Index(int pageNumber = 1)
        {
            var paged = _osAppService.ObterTodosPaginado(PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.SearchNumber = pageNumber;

            return View(paged.Lista);
        }

        [Route("detalhes/{id:int}")]
        [ClaimsAuthorize("GestaoOs", "DE")]
        public ActionResult Details(int id)
        {
            var ordemDeServicoViewModel = _osAppService.ObterPorId(id);

            var clienteId = ordemDeServicoViewModel.ClienteId;

            ViewBag.ClienteId = clienteId;

            ViewBag.ListaDeClientes = ObterSelectListComNomeDosClientes(_clienteAppService.ObterPorIdSemEndereco(clienteId));

            ordemDeServicoViewModel.Observacao = "";

            return View(ordemDeServicoViewModel);
        }

        [Route("lançar")]
        [ClaimsAuthorize("GestaoOs", "IN")]
        public ActionResult Create()
        {
            ViewBag.ListaDeClientes = ObterSelectListComNomeDosClientes(_clienteAppService.ObterTodos().ToArray());
            ViewBag.Sistemas = ObterSelectListComNomeDosSistemas(_sistemaAppService.ObterTodos().ToArray());
            ViewBag.Modulos = ObterSelectListComNomeDosModulos(_moduloAppService.ObterTodos().ToArray());
            ViewBag.Programadores = ObterSelectListComNomeDosProgramadores(_programadorAppService.ObterProgramadoresDto().ToArray());
            ViewBag.UserId = UserId;

            return View();
        }

        [HttpPost]
        [Route("lançar")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoOs", "IN")]
        public ActionResult Create(OrdemDeServicoViewModel ordemDeServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                _osAppService.Adicionar(ordemDeServicoViewModel, UserId);
                return RedirectToAction("Index");
            }

            return View(ordemDeServicoViewModel);
        }

        [Route("editar/{id:int}")]
        [ClaimsAuthorize("GestaoOs", "ED")]
        public ActionResult Edit(int id)
        {
            var ordemDeServicoViewModel = _osAppService.ObterPorId(id);
            ordemDeServicoViewModel.TecnicoId = UserId;

            ViewBag.ListaDeClientes = ObterSelectListComNomeDosClientes(_clienteAppService.ObterTodos().ToArray());
            ViewBag.ClienteId = ordemDeServicoViewModel.ClienteId;
            ViewBag.Sistemas = new SelectList(_sistemaAppService.ObterTodos(), "Nome", "Nome", ordemDeServicoViewModel.Sistema);
            ViewBag.Modulos = new SelectList(_moduloAppService.ObterTodos(), "Nome", "Nome", ordemDeServicoViewModel.Modulo);
            ViewBag.UserId = UserId;

            return View(ordemDeServicoViewModel);
        }
        
        [HttpPost]
        [Route("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoOs", "ED")]
        public ActionResult Edit(OrdemDeServicoViewModel ordemDeServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                _osAppService.Atualizar(ordemDeServicoViewModel);
                return RedirectToAction("Index");
            }
            return View(ordemDeServicoViewModel);
        }

        [Route("deletar/{id:int}")]
        [ClaimsAuthorize("GestaoOs", "EX")]
        public ActionResult Delete(int id)
        {
            var ordemDeServicoViewModel = _osAppService.ObterPorId(id);
            // TODO Arrumar null de propriedade observação
            ordemDeServicoViewModel.Observacao = "";
            return View(ordemDeServicoViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [Route("deletar/{id:int}")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("GestaoOs", "EX")]
        public ActionResult DeleteConfirmed(int id)
        {
            _osAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public string ObterUsuario(Guid clienteId)
        {
            var usuario = _clienteAppService.ObterUsuario(clienteId);
            return usuario;
        }

        protected override void Dispose(bool disposing)
        {
            _osAppService.Dispose();
        }
        
        // TODO código repetido, 2 métodos iguais (USAR DTOS)
        private ICollection<SelectListItem> ObterSelectListComNomeDosClientes(params ClienteViewModel[] listaDeClientes)
        {
            ICollection<SelectListItem> list = new List<SelectListItem>();

            foreach (var  item in listaDeClientes)
            {
                list.Add(new SelectListItem { Text = item.Nome, Value = item.Id.ToString()});
            }

            return list;
        }

        private ICollection<SelectListItem> ObterSelectListComNomeDosSistemas(params SistemaViewModel[] listaDeClientes)
        {
            ICollection<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in listaDeClientes)
            {
                list.Add(new SelectListItem { Text = item.Nome, Value = item.Nome });
            }

            return list;
        }

        private ICollection<SelectListItem> ObterSelectListComNomeDosModulos(params ModuloViewModel[] listaDeClientes)
        {
            ICollection<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in listaDeClientes)
            {
                list.Add(new SelectListItem { Text = item.Nome, Value = item.Nome });
            }

            return list;
        }

        private ICollection<SelectListItem> ObterSelectListComNomeDosProgramadores(params ProgramadorViewModel[] listaDeClientes)
        {
            ICollection<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in listaDeClientes)
            {
                list.Add(new SelectListItem { Text = item.Nome, Value = item.Nome });
            }

            return list;
        }
    }
}
