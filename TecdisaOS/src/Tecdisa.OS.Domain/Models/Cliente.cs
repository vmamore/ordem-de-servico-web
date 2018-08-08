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
        public bool Excluido { get; private set; }

        public int Atividade { get; set; }
        public int Tabela { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual TI UsuarioTI{ get; set; }
        public virtual Expedicao UsuarioExpedicao { get; set; }
        public virtual Faturista UsuarioFaturamento { get; set; }
        public virtual Financeiro UsuarioFinanceiro { get; set; }
        public virtual Comercial UsuarioComercial { get; set; }
        public virtual Contabil UsuarioContabil { get; set; }

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
