using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecdisa.OS.Application.ViewModel
{
    public class SistemaViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Sistema")]
        [Required(ErrorMessage = "Preencha o campo Sistema")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        public string Nome { get; set; }
        
        public bool Ativo { get; set; }

        public bool Excluido { get; set; }
        
        public ICollection<ModuloViewModel> Modulos { get; set; }
    }
}
