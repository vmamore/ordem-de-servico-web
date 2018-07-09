using System.Collections.Generic;

namespace Tecdisa.OS.Domain.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
