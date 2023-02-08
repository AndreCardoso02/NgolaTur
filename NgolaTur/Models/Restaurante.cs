using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class Restaurante
    {
        [Key]
        [Display(Name = "Id do Restaurante")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeRestaurante { get; set; }

        [ForeignKey(nameof(Models.Cidade.Id))]
        [Display(Name = "Cidade")]
        public int IdCidade { get; set; }
        [ForeignKey(nameof(Models.CategoriaRestaurante.Id))]
        [Display(Name = "Categoria do restaurante")]
        public int IdCategoriaRestaurante { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual CategoriaRestaurante CategoriaRestaurante { get; set; }
    }
}
