namespace Tecdisa.OS.Domain.Models
{
    public class Programador : Pessoa
    {
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

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
