using System;
using System.Collections.Generic;
using Tecdisa.OS.Domain.ValueObjects;

namespace Tecdisa.OS.Domain.Models
{
    public class Cliente : Entity
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }

        public bool Ativo { get; private set; }
        public bool Excluido { get; set; }

        public int Atividade { get; set; }
        public int Tabela { get; set; }

        public DateTime DataCadastro { get; set; }

        public TI UsuarioTI{ get; set; }
        public Expedicao UsuarioExpedicao { get; set; }
        public Faturista UsuarioFaturista { get; set; }
        public Financeiro UsuarioFinanceiro { get; set; }
        public Comercial UsuarioComercial { get; set; }
        public Contabil UsuarioContabil { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; protected set; }

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

        public override bool EhValido()
        {
            return true;
        }

        public void AdicionarEndereco(Endereco e)
        {
            if (!e.EhValido())
                return;

            Enderecos.Add(e);
        }
    }
}
