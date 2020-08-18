using System;
using System.ComponentModel.DataAnnotations;
using VehicleControl.CrossCutting.DTO.Base;

namespace VehicleControl.CrossCutting.DTO.Anuncio
{
    public class AnuncioUpdateDTO : BaseUpdateDTO
    {
        [Required]
        public int Ano { get; set; }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        [StringLength(100)]
        public string Cor { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoCombustivel { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [Required]
        public Guid MarcaKey { get; set; }

        [Required]
        public Guid ModeloKey { get; set; }
    }
}
