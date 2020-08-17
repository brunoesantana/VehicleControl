using System.ComponentModel.DataAnnotations;
using VehicleControl.CrossCutting.DTO.Base;

namespace VehicleControl.CrossCutting.DTO.Anuncio
{
    public class AnuncioUpdateDTO : BaseUpdateDTO
    {
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
    }
}
