using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Data;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Model;

namespace Tecdisa.OS.Infra.CrossCutting.Loggin.Helpers
{
    public class LogAuditoriaHelper : ILogAuditoria
    {
        private readonly LogContext _context;
        public Dictionary<string, string> Item = new Dictionary<string, string>();

        public LogAuditoriaHelper(LogContext context)
        {
            _context = context;
        }

        public void RegistarLog(ActionExecutedContext filterContext)
        {
            try
            {
                var modelJson = "";

                if (filterContext.HttpContext.Request.HttpMethod.ToLower() == "post")
                {
                    var form = Form(filterContext.HttpContext);
                    form.Remove(form.First(c => c.Key == "__RequestVerificationToken"));
                    modelJson = form.Aggregate("{", (current, item) => current + string.Format("'{0}':" + "'{1}',", item.Key, item.Value)) + "}";
                }

                var usuarioEstaAutenticado = filterContext.HttpContext.User.Identity.IsAuthenticated;

                var log = new Auditoria(
                    usuarioEstaAutenticado ? filterContext.HttpContext.User.Identity.GetUserName() : "Anonimo",
                    "Tecdisa OS",
                    GetIp(filterContext),
                    filterContext.HttpContext.Request.Url.AbsoluteUri,
                    modelJson
                    );

                _context.LogAuditoria.Add(log);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                // Grava log de erro
            }
        }

        public IEnumerable<Auditoria> Buscar(Expression<Func<Auditoria, bool>> predicate)
        {
            return _context.LogAuditoria.Where(predicate);
        }
        public IEnumerable<Auditoria> ObterLogs()
        {
            return _context.LogAuditoria.OrderBy(c => c.DataOcorrencia).ToList();
        }

        private static List<Item> Form(HttpContextBase httpContext)
        {
            return httpContext.Request.Form.Keys.OfType<string>().Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
        }

        private string GetIp(ActionExecutedContext filterContext)
        {
            return filterContext.HttpContext.Request.ServerVariables["SERVER_NAME"] == "localhost" ? "Acesso Local" : filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
        }
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }

    public class Item
    {
        public Item(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }

}
