using System;
using Tecdisa.OS.Domain.ValueObjects;

namespace Tecdisa.OS.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }

        public int Atividade { get; set; }
        public int Tabela { get; set; }

        public TI UsuarioTI{ get; set; }
        public Expedicao UsuarioExpedicao { get; set; }
        public Faturista UsuarioFaturista { get; set; }
        public Financeiro UsuarioFinanceiro { get; set; }
        public Comercial UsuarioComercial { get; set; }

        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
