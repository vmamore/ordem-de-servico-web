using System.Collections.Generic;

namespace Tecdisa.OS.Domain.Models
{
    public class Sistema
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }
        public ICollection<Modulo> Modulos { get; set; }

        public void Ativar()
        {
            Ativo = true;
            Excluido = false;
        }

        public void Excluir()
        {
            Ativo = false;
            Excluido = true;
        }

    }
}
