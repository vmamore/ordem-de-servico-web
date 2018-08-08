using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Helpers;

namespace Tecdisa.OS.Infra.CrossCutting.MvcFilters
{
    public class GlobalFilterTools : ActionFilterAttribute
    {
        private readonly ILogAuditoria _logAuditoria;

        public GlobalFilterTools(ILogAuditoria logAuditoria)
        {
            _logAuditoria = logAuditoria;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _logAuditoria.RegistarLog(filterContext);
        }
    }
}
