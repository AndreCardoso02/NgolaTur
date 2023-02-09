using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.ViewModels
{
    public class HomeDestaquesViewModel
    {
        public HomeDestaquesViewModel()
        {
            Hoteis = new List<HomeDestaquesItemViewModel>();
            PontosTuristicos = new List<HomeDestaquesItemViewModel>();
            Restaurantes = new List<HomeDestaquesItemViewModel>();
        }

        public List<HomeDestaquesItemViewModel> Hoteis { get; set; }
        public List<HomeDestaquesItemViewModel> PontosTuristicos { get; set; }
        public List<HomeDestaquesItemViewModel> Restaurantes { get; set; }
    }

    public class HomeDestaquesItemViewModel
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Classificacao { get; set; }
        public string UrlImage { get; set; }
        public TipoDestaque Tipo { get; set; }
        public object Data { get; set; }
    }

    public enum TipoDestaque
    {
        Hotel,
        PontoTuristico,
        Restaurante
    }
}
