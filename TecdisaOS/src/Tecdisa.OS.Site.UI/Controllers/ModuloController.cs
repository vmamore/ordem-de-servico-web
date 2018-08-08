using System.Web.Mvc;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;

namespace Tecdisa.OS.Site.UI.Controllers
{
    [RoutePrefix("modulos")]
    public class ModuloController : Controller
    {
        private readonly IModuloAppService _moduloAppService;
        private readonly ISistemaAppService _sistemaAppService;


        public ModuloController(IModuloAppService moduloAppService, ISistemaAppService sistemaAppService)
        {
            _moduloAppService = moduloAppService;
            _sistemaAppService = sistemaAppService;
        }
        
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_moduloAppService.ObterTodosComSistema());
        }

        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            var moduloViewModel = _moduloAppService.ObterPorId(id);
            ViewBag.Sistemas = _sistemaAppService.ObterTodos();
            ViewBag.SistemaSelecionado = moduloViewModel.SistemaId;

            return View(moduloViewModel);
        }
        
        [Route("criar")]
        public ActionResult Create()
        {
            ViewBag.Sistemas = _sistemaAppService.ObterTodos();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar")]
        public ActionResult Create(ModuloViewModel moduloViewModel)
        {
            if (ModelState.IsValid)
            {
                _moduloAppService.Adicionar(moduloViewModel);
                return RedirectToAction("Index");
            }
            return View(moduloViewModel);
        }
        
        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var moduloViewModel = _moduloAppService.ObterPorId(id);
            ViewBag.Sistemas = _sistemaAppService.ObterTodos();
            ViewBag.SistemaSelecionado = moduloViewModel.SistemaId;

            return View(moduloViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{id:int}")]
        public ActionResult Edit(ModuloViewModel moduloViewModel)
        {
            if (ModelState.IsValid)
            {
                _moduloAppService.Atualizar(moduloViewModel);
                return RedirectToAction("Index");
            }

            return View(moduloViewModel);
        }

        [Route("deletar/{id:int}")]
        public ActionResult Delete(int id)
        {
            var moduloViewModel = _moduloAppService.ObterPorId(id);
            ViewBag.Sistema = moduloViewModel.Sistema.Nome;

            return View(moduloViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            _moduloAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _moduloAppService.Dispose();
        }
    }
}
