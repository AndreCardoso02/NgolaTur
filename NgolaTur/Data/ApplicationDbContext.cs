using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NgolaTur.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgolaTur.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<TipoQuarto> TipoQuarto { get; set; }
        public DbSet<TipoPontoTuristico> TipoPontoTuristico { get; set; }
        public DbSet<ClassificacaoHotel> ClassificacaoHotel { get; set; }
        public DbSet<CategoriaRestaurante> CategoriaRestaurante { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<PontoTuristico> PontoTuristico { get; set; }
        public DbSet<ReservaRestaurante> ReservaRestaurante { get; set; }
        public DbSet<ReservaQuartoHotel> ReservaQuartoHotel { get; set; }
        public DbSet<ReservaPontoTuristico> ReservaPontoTuristico { get; set; }
    }
}
