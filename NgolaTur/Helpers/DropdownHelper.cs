using Microsoft.AspNetCore.Mvc.Rendering;
using NgolaTur.Data;
using NgolaTur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Helpers
{
    public static class DropdownHelper
    {
        public static SelectList GetProvinciasList(ApplicationDbContext context)
        {
            var provincias = context.Provincia.ToList();
            provincias.Add(new Provincia
            {
                Id = 0,
                NomeProvincia = "-- Selecione --"
            });

            provincias = provincias.OrderBy(p => p.NomeProvincia).ToList();

            return new SelectList(provincias, "Id", "NomeProvincia");

        }

        public static SelectList GetCidadesList(ApplicationDbContext context)
        {
            var cidades = context.Cidade.ToList();
            cidades.Add(new Cidade
            {
                Id = 0,
                NomeCidade = "-- Selecione --"
            });

            cidades = cidades.OrderBy(p => p.NomeCidade).ToList();

            return new SelectList(cidades, "Id", "NomeCidade");
        }

        public static SelectList GetClassificacaoHotelList(ApplicationDbContext context)
        {
            var classHotel = context.ClassificacaoHotel.ToList();
            classHotel.Add(new ClassificacaoHotel
            {
                Id = 0,
                NomeClassificacaoHotel = "-- Selecione --"
            });

            classHotel = classHotel.OrderBy(p => p.NomeClassificacaoHotel).ToList();

            return new SelectList(classHotel, "Id", "NomeClassificacaoHotel");
        }

        public static SelectList GetTipoPontoTuristicoList(ApplicationDbContext context)
        {
            var tPontoTuristico = context.TipoPontoTuristico.ToList();
            tPontoTuristico.Add(new TipoPontoTuristico
            {
                Id = 0,
                NomeTipoPontoTuristico = "-- Selecione --"
            });

            tPontoTuristico = tPontoTuristico.OrderBy(p => p.NomeTipoPontoTuristico).ToList();

            return new SelectList(tPontoTuristico, "Id", "NomeTipoPontoTuristico");
        }

        public static SelectList GetPontoTuristicoList(ApplicationDbContext context)
        {
            var pontoTuristicos = context.PontoTuristico.ToList();
            pontoTuristicos.Add(new PontoTuristico
            {
                Id = 0,
                NomePontoTuristico = "-- Selecione --"
            });

            pontoTuristicos = pontoTuristicos.OrderBy(p => p.NomePontoTuristico).ToList();

            return new SelectList(pontoTuristicos, "Id", "NomePontoTuristico");
        }

        public static SelectList GetHotelList(ApplicationDbContext context)
        {
            var hoteis = context.Hotel.ToList();
            hoteis.Add(new Hotel
            {
                Id = 0,
                NomeHotel = "-- Selecione --"
            });

            hoteis = hoteis.OrderBy(p => p.NomeHotel).ToList();

            return new SelectList(hoteis, "Id", "NomeHotel");
        }

        public static SelectList GetUsuarioList(ApplicationDbContext context)
        {
            var usuarios = context.Users.ToList();
            usuarios.Add(new Microsoft.AspNetCore.Identity.IdentityUser
            {
                Id = "0",
                Email = "-- Selecione --"
            });

            usuarios = usuarios.OrderBy(p => p.Email).ToList();

            return new SelectList(usuarios, "Id", "Email");
        }

        public static SelectList GetCategoriaRestauranteList(ApplicationDbContext context)
        {
            var catRestaurantes = context.CategoriaRestaurante.ToList();
            catRestaurantes.Add(new CategoriaRestaurante
            {
                Id = 0,
                TipoCategoria = "-- Selecione --"
            });

            catRestaurantes = catRestaurantes.OrderBy(p => p.TipoCategoria).ToList();

            return new SelectList(catRestaurantes, "Id", "TipoCategoria");
        }

        public static SelectList GetRestaurantesList(ApplicationDbContext context)
        {
            var restaurantes = context.Restaurante.ToList();
            restaurantes.Add(new Restaurante
            {
                Id = 0,
                NomeRestaurante = "-- Selecione --"
            });

            restaurantes = restaurantes.OrderBy(p => p.NomeRestaurante).ToList();

            return new SelectList(restaurantes, "Id", "NomeRestaurante");
        }

        public static SelectList GetTipoQuartoHotelList(ApplicationDbContext context)
        {
            var tipoQuartos = context.TipoQuarto.ToList();
            tipoQuartos.Add(new TipoQuarto
            {
                Id = 0,
                NomeTipoQuarto = "-- Selecione --"
            });

            tipoQuartos = tipoQuartos.OrderBy(p => p.NomeTipoQuarto).ToList();

            return new SelectList(tipoQuartos, "Id", "NomeTipoQuarto");
        }
    }
}
