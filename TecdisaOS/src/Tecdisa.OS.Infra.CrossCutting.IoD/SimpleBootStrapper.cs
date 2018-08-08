using SimpleInjector;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.Services;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Services;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Data;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Helpers;
using Tecdisa.OS.Infra.Data.Context;
using Tecdisa.OS.Infra.Data.Repository;
using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Infra.CrossCutting.IoD
{
    public class SimpleBootStrapper
    {
        public static void Register(Container container)
        {

            // Application
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IOrdemDeServicoAppService, OrdemDeServicoAppService>(Lifestyle.Scoped);
            container.Register<IProgramadorAppService, ProgramadorAppService>(Lifestyle.Scoped);
            container.Register<ISistemaAppService, SistemaAppService>(Lifestyle.Scoped);
            container.Register<IModuloAppService, ModuloAppService>(Lifestyle.Scoped);


            // Domain

            // Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IOrdemDeServicoRepository, OrdemDeServicoRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EndereçoRepository>(Lifestyle.Scoped);
            container.Register<IProgramadorRepository, ProgramadorRepository>(Lifestyle.Scoped);
            container.Register<ISistemaRepository, SistemaRepository>(Lifestyle.Scoped);
            container.Register<IModuloRepository, ModuloRepository>(Lifestyle.Scoped);
            container.Register<IEmailService, EmailService>(Lifestyle.Singleton);
            container.Register<IOrdemDeServicoService, OrdemDeServicoService>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TecdisaContext>(Lifestyle.Scoped);

            // Login
            container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            container.Register<LogContext>(Lifestyle.Scoped);
        }
    }
}
