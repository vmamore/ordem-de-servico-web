using System.Linq;
using System.Threading.Tasks;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Services
{
    public class OrdemDeServicoService : IOrdemDeServicoService
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;
        private readonly IProgramadorRepository _programadorRepository;
        private readonly IEmailService _emailService;
        
        public OrdemDeServicoService(IOrdemDeServicoRepository osRepository, 
            IProgramadorRepository programdorRepository, IEmailService emailService)
        {
            _ordemDeServicoRepository = osRepository;
            _programadorRepository = programdorRepository;
            _emailService = emailService;
        }

        public OrdemDeServico Adicionar(OrdemDeServico os)
        {
            if (os.NecessitaDeAjuste)
            {
                var programador = _programadorRepository.ObterPorNome(os.Programador).FirstOrDefault();
                _emailService.SendEmail(os, programador);
            }
            return _ordemDeServicoRepository.Adicionar(os);
        }
    }
}
