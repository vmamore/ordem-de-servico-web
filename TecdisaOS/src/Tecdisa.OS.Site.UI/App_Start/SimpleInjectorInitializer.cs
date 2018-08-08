[assembly: WebActivator.PostApplicationStartMethod(typeof(Tecdisa.OS.Site.UI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Tecdisa.OS.Site.UI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Tecdisa.OS.Infra.CrossCutting.IoD;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleBootStrapper.Register(container);
        }
    }
}