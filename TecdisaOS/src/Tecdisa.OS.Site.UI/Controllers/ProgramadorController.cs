using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Site.UI.Models;

namespace Tecdisa.OS.Site.UI.Controllers
{
    [RoutePrefix("programadores")]
    public class ProgramadorController : Controller
    {
        private readonly IProgramadorAppService programadorAppService;

        public ProgramadorController(IProgramadorAppService service)
        {
            programadorAppService = service;
        }
        
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(programadorAppService.ObterTodos());
        }
        
        [Route("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            var programadorViewModel = programadorAppService.ObterPorId(id);
            return View(programadorViewModel);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("criar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ProgramadorViewModel programadorViewModel)
        {
            if (ModelState.IsValid)
            {
                programadorAppService.Adicionar(programadorViewModel);
                return RedirectToAction("Index");
            }

            return View(programadorViewModel);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var programadorViewModel = programadorAppService.ObterPorId(id);
            
            return View(programadorViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{id:int}")]
        public ActionResult Edit(ProgramadorViewModel programadorViewModel)
        {
            if (ModelState.IsValid)
            {
                programadorAppService.Atualizar(programadorViewModel);
                return RedirectToAction("Index");
            }
            return View(programadorViewModel);
        }

        [Route("deletar/{id:int}")]
        public ActionResult Delete(int id)
        {
            var programadorViewModel = programadorAppService.ObterPorId(id);
            return View(programadorViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            programadorAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            programadorAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}
