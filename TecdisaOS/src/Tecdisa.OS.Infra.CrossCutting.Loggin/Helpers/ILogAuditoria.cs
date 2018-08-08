using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Model;

namespace Tecdisa.OS.Infra.CrossCutting.Loggin.Helpers
{
    public interface ILogAuditoria : IDisposable
    {
        void RegistarLog(ActionExecutedContext filterContext);
        IEnumerable<Auditoria> ObterLogs();
        IEnumerable<Auditoria> Buscar(Expression<Func<Auditoria, bool>> boolean);
    }
}
