using System;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;

namespace VehicleControl.CrossCutting.DTO.Anuncio
{
    public class AnuncioDTO
    {
        public Guid Id { get; set; }
        public int Ano { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorLucro { get; set; }
        public MarcaDTO Marca { get; set; }
        public ModeloDTO Modelo { get; set; }
    }
}
