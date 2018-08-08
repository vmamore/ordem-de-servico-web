using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecdisa.OS.Domain.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
