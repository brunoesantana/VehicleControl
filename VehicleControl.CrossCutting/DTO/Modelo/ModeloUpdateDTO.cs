using System.ComponentModel.DataAnnotations;
using VehicleControl.CrossCutting.DTO.Base;

namespace VehicleControl.CrossCutting.DTO.Modelo
{
    public class ModeloUpdateDTO : BaseUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Detail { get; set; }
    }
}
