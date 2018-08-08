using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TecdisaContext _context;

        public UnitOfWork(TecdisaContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
