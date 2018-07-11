using System.ComponentModel.DataAnnotations;

namespace Tecdisa.OS.Application.ViewModel
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "Campo Logradouro obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Bairro obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Número obrigatório")]
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo CEP obrigatório")]
        [MaxLength(8, ErrorMessage = "Máximo de 8 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo de 8 caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo Cidade obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Estado obrigatório")]
        [MaxLength(2, ErrorMessage = "Máximo de 2 caracteres")]
        [Display(Name = "Estado")]
        public string UF { get; set; }
    }
}
