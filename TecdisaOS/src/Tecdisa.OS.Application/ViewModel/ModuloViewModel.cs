using System.ComponentModel.DataAnnotations;

namespace Tecdisa.OS.Application.ViewModel
{
    public class ModuloViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
        
        [ScaffoldColumn(false)]
        public int SistemaId { get; set; }

        [ScaffoldColumn(false)]
        public SistemaViewModel Sistema { get; set; }
    }
}
