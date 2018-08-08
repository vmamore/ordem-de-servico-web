using SimpleInjector;
using System.Web.Mvc;
using Tecdisa.OS.Infra.CrossCutting.MvcFilters;

namespace Tecdisa.OS.Site.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTools>());
        }
    }
}
