using System.ComponentModel.DataAnnotations;

namespace Tecdisa.OS.Application.ViewModel
{
    public class ProgramadorViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Nome { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo E-mail obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }
    }
}
