using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class CategoriaRestaurante
    {
        [Key]
        [Display(Name = "Id da Categoria")]
        public int Id { get; set; }
        [Display(Name = "Tipo da Categoria")]
        public string TipoCategoria { get; set; }

        public virtual IEnumerable<Restaurante> Restaurantes { get; set; }
    }
}
