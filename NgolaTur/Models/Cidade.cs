using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class Cidade
    {
        [Key]
        [Display(Name = "Id da Cidade")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeCidade { get; set; }
        [Display(Name = "Estado")]
        public string EstadoCidade { get; set; }

        [Display(Name = "Província")]
        [ForeignKey(nameof(Models.Provincia.Id))]
        public int IdProvincia { get; set; }
        [Display(Name = "População")]
        public int Populacao { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual IEnumerable<Restaurante> Restaurantes { get; set; }
        public virtual IEnumerable<Hotel> Hoteis { get; set; }
        public virtual IEnumerable<PontoTuristico> PontosTuristicos { get; set; }
    }
}
