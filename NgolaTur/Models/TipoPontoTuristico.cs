using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class TipoPontoTuristico
    {
        [Key]
        [Display(Name = "Id do Tipo do Ponto Turistico")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeTipoPontoTuristico { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        public virtual IEnumerable<PontoTuristico> PontosTuristicos { get; set; }
    }
}
