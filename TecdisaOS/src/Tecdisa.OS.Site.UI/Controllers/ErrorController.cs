using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tecdisa.OS.Site.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ViewBag.Erro = "Página não encontrada";
            ViewBag.Mensagem = "Ação solicitada não foi encontrada!";
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.Erro = "Acesso Proibido!";
            ViewBag.Mensagem = "Você não pode acessar esta tela!";

            return View("Error");
        }

        public ActionResult ServerError()
        {
            ViewBag.Erro = "Erro de Servidor";
            ViewBag.Mensagem = "Erro interno no servidor. Tente novamente em instantes ou contate o administrador";
            return View("Error");
        }
    }
}