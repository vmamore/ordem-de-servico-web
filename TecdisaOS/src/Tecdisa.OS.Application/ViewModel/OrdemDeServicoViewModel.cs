using System;
using System.ComponentModel.DataAnnotations;

namespace Tecdisa.OS.Application.ViewModel
{
    public class OrdemDeServicoViewModel
    {
        public OrdemDeServicoViewModel()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "Cliente")]
        public string ClienteNome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Abertura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Abertura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm}")]
        public DateTime HoraCadastro { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Fechamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataDeFechamento { get; set; }
        
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Fechamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm}")]
        public DateTime HoraDeFechamento { get; set; }

        [Display(Name = "Necessita de Ajuste")]
        public bool NecessitaDeAjuste { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        [MaxLength(100, ErrorMessage = "Preencha com máximo de 100 caracteres")]
        public string NomeDoFaturista { get; set; }
        
        [Display(Name = "Programador")]
        public string Programador { get; set; }

        [Required(ErrorMessage = "Campo Sistema obrigatório")]
        [Display(Name = "Sistema")]
        public string Sistema { get; set; }

        [Required(ErrorMessage = "Campo Módulo obrigatório")]
        [Display(Name = "Módulo")]
        public string Modulo { get; set; }

        [Required(ErrorMessage = "Campo Problema obrigatório")]
        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        [Display(Name = "Problema")]
        public string Problema { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        [Display(Name = "Solução")]
        public string Solucao { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        
        public string TecnicoId { get; set; }
    }
}
