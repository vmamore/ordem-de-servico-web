using System;
using Tecdisa.OS.Domain.ValueObjects;

namespace Tecdisa.OS.Domain.Models
{
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime HoraCadastro { get; set; }
        public DateTime DataDeFechamento { get; set; }
        public DateTime HoraDeFechamento { get; set; }

        public bool NecessitaDeAjuste { get; set; }
        public bool Excluido { get; private set; }

        public string NomeDoFaturista { get; set; }

        public string TecnicoId { get; set; }
        public string Programador { get; set; }

        public string Sistema { get; set; }
        public string Modulo { get; set; }

        public string Problema { get; set; }
        public string Solucao { get; set; }
        public string Observacao { get; set; }

        public void Excluir()
        {
            Excluido = true;
        }

    }
}
