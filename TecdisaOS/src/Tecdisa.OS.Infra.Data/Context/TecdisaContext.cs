using System.Data.Entity;

namespace Tecdisa.OS.Infra.Data.Context
{
    public class TecdisaContext : DbContext
    {
        public TecdisaContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
