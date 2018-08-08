using System.ComponentModel.DataAnnotations;

namespace Tecdisa.OS.Application.ViewModel
{
    public class TecnicoViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo E-mail obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Email { get; set; }
    }
}
