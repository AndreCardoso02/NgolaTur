using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class ReservaRestaurante
    {
        [Key]
        [Display(Name = "Id da Reserva")]
        public int Id { get; set; }
        [Display(Name = "Data de entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data de saída")]
        public DateTime DataSaida { get; set; }

        [ForeignKey(nameof(Restaurante.Id))]
        [Display(Name = "Restaurante")]
        public int IdRestaurante { get; set; }
        [ForeignKey(nameof(IdentityUser.Id))]
        [Display(Name = "Usuário")]
        public string IdUsuario { get; set; }
        public virtual Restaurante PontoTuristico { get; set; }
        public virtual IdentityUser Usuario { get; set; }
    }
}
