using System;

namespace VehicleControl.CrossCutting.DTO.Modelo
{
    public class ModeloDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
