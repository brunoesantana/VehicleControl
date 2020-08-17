using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleControl.CrossCutting.DTO.Anuncio
{
    public class AnuncioInsertDTO
    {
        [Required]
        public int Ano { get; set; }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public string TipoCombustivel { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [Required]
        public Guid MarcaKey { get; set; }

        [Required]
        public Guid ModeloKey { get; set; }
    }
}
