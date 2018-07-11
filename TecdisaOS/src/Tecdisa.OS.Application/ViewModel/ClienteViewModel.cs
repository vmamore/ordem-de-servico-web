using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecdisa.OS.Application.ViewModel
{
    // TODO verificar relacionamentos
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Id = Guid.NewGuid();
        }
        
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo de 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Fantasia obrigatório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Campo CNPJ obrigatório")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [MinLength(14, ErrorMessage = "Mínimo de 14 caracteres")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo Inscrição Estadual obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "Campo Telefone obrigatório")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Tabela obrigatório")]
        public int Tabela { get; set; }

        [Required(ErrorMessage = "Campo Atividade obrigatório")]
        public int Atividade { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Campo Usuário Faturamento obrigatório")]
        [Display(Name = "Usuário Faturamento")]
        public string UsuarioFaturamento { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Campo Usuário Financeiro obrigatório")]
        [Display(Name = "Usuário Financeiro")]
        public string UsuarioFinanceiro { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Campo Usuário Expedição obrigatório")]
        [Display(Name = "Usuário Expedição")]
        public string UsuarioExpedicao { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Campo Usuário TI obrigatório")]
        [Display(Name = "Usuário TI")]
        public string UsuarioTI { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Campo E-mail Faturamento obrigatório")]
        [Display(Name = "E-mail Faturamento")]
        [DataType(DataType.EmailAddress)]
        public string EmailFaturamento { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Campo E-mail Financeiro obrigatório")]
        [Display(Name = "E-mail Financeiro")]
        [DataType(DataType.EmailAddress)]
        public string EmailFinanceiro { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Campo E-mail Contador obrigatório")]
        [Display(Name = "E-mail Contador")]
        [DataType(DataType.EmailAddress)]
        public string EmailContador { get; set; }
        
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
