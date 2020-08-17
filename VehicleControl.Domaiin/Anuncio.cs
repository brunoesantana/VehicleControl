using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleControl.Domain.Base;

namespace VehicleControl.Domain
{
    public class Anuncio : EntityBase
    {
        [Required]
        [Column(TypeName = "INT")]
        public int Ano { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(12,2)")]
        public decimal ValorCompra { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(12,2)")]
        public decimal ValorVenda { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Cor { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string TipoCombustivel { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        [StringLength(50)]
        public DateTime DataVenda { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public Guid MarcaKey { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public Guid ModeloKey { get; set; }
    }
}
