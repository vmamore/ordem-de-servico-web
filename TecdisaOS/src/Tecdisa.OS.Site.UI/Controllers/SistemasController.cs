using System.Web.Mvc;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;

namespace Tecdisa.OS.Site.UI.Controllers
{
    [RoutePrefix("sistemas")]
    public class SistemasController : Controller
    {
        private readonly ISistemaAppService _sistemaAppService;

        public SistemasController(ISistemaAppService appService)
        {
            _sistemaAppService = appService;
        }

        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_sistemaAppService.ObterTodos());
        }
        
        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            
            var sistemaViewModel = _sistemaAppService.ObterPorId(id);
            return View(sistemaViewModel);
        }
        
        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Route("criar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SistemaViewModel sistemaViewModel)
        {
            if (ModelState.IsValid)
            {
                _sistemaAppService.Adicionar(sistemaViewModel);
                return RedirectToAction("Index");
            }

            return View(sistemaViewModel);
        }
        
        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {

            var sistemaViewModel = _sistemaAppService.ObterPorId(id);
            return View(sistemaViewModel);
        }
        
        [HttpPost]
        [Route("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SistemaViewModel sistemaViewModel)
        {
            if (ModelState.IsValid)
            {
                _sistemaAppService.Atualizar(sistemaViewModel);
                return RedirectToAction("Index");
            }
            return View(sistemaViewModel);
        }
        
        [Route("deletar/{id:int}")]
        public ActionResult Delete(int id)
        {
            var sistemaViewModel = _sistemaAppService.ObterPorId(id);
            return View(sistemaViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            _sistemaAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _sistemaAppService.Dispose();
        }
    }
}
