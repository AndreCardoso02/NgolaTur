using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class Provincia
    {
        [Key]
        [Display(Name = "Id da Província")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeProvincia { get; set; }
        [Display(Name = "Estado")]
        public string EstadoProvincia { get; set; }

        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}
