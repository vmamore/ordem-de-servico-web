using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Application.Services
{
    public abstract class AppService
    {
        protected readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            return _uow.Commit() > 0;
        }
    }
}
