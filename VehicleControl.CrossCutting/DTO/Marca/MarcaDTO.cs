using System;

namespace VehicleControl.CrossCutting.DTO.Marca
{
    public class MarcaDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
