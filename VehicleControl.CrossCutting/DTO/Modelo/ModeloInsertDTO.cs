using System.ComponentModel.DataAnnotations;

namespace VehicleControl.CrossCutting.DTO.Modelo
{
    public class ModeloInsertDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Detail { get; set; }
    }
}
