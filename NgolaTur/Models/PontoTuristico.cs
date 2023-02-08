using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class PontoTuristico
    {
        [Key]
        [Display(Name = "Id do Ponto Turístico")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomePontoTuristico { get; set; }

        [ForeignKey(nameof(Models.Cidade.Id))]
        [Display(Name = "Cidade")]
        public int IdCidade { get; set; }
        [ForeignKey(nameof(Models.TipoPontoTuristico.Id))]
        [Display(Name = "Tipo do ponto turístico")]
        public int IdTipoPontoTuristico { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual TipoPontoTuristico TipoPontoTuristico { get; set; }
    }
}
