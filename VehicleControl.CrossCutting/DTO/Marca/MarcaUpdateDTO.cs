using System.ComponentModel.DataAnnotations;
using VehicleControl.CrossCutting.DTO.Base;

namespace VehicleControl.CrossCutting.DTO.Marca
{
    public class MarcaUpdateDTO : BaseUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
