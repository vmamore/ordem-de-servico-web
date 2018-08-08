using System.Threading.Tasks;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Services
{
    public interface IEmailService
    {
        void SendEmail(OrdemDeServico os, Programador programador);
    }
}
