namespace Tecdisa.OS.Domain.Models
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        
        public int SistemaId { get; set; }
        public Sistema Sistema { get; set; }

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
