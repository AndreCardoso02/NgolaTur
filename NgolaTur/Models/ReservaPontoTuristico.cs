using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class ReservaPontoTuristico
    {
        [Key]
        [Display(Name = "Id da Reserva")]
        public int Id { get; set; }
        [Display(Name = "Data de entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data de saída")]
        public DateTime DataSaida { get; set; }

        [ForeignKey(nameof(Models.PontoTuristico.Id))]
        [Display(Name = "Ponto turístico")]
        public int IdPontoTuristico { get; set; }
        [ForeignKey(nameof(IdentityUser.Id))]
        [Display(Name = "Usuário")]
        public string IdUsuario { get; set; }
        public virtual PontoTuristico PontoTuristico { get; set; }
        public virtual IdentityUser Usuario { get; set; }
    }
}
