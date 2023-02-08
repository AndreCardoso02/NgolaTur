using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class ClassificacaoHotel
    {
        [Key]
        [Display(Name = "Id da Classificação")]
        public int Id { get; set; }
        [Display(Name = "Classificação")]
        public string NomeClassificacaoHotel { get; set; }
        public virtual IEnumerable<Hotel> Hoteis { get; set; }
    }
}
