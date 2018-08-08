using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class EndereçoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EndereçoRepository(TecdisaContext db) : base(db)
        {

        }
    }
}
