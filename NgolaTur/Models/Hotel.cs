using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class Hotel
    {
        [Key]
        [Display(Name = "Id do Hotel")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeHotel { get; set; }
        [Display(Name = "Estado")]
        public string EstadoHotel { get; set; }

        [ForeignKey(nameof(Models.Cidade.Id))]
        [Display(Name = "Cidade")]
        public int IdCidade { get; set; }
        [ForeignKey(nameof(Models.ClassificacaoHotel.Id))]
        [Display(Name = "Classificação")]
        public int IdClassificacaoHotel { get; set; }
        [Display(Name = "Número de quartos")]
        public int NumeroDeQuartos { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ClassificacaoHotel ClassificacaoHotel { get; set; }
        public virtual IEnumerable<TipoQuarto> TiposDeQuartos { get; set; }
    }
}
