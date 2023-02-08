using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class TipoQuarto
    {
        [Key]
        [Display(Name = "Id do Tipo de Quarto")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeTipoQuarto { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [ForeignKey(nameof(Models.Hotel.Id))]
        [Display(Name = "Hotel")]
        public int IdHotel { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
