using System.ComponentModel.DataAnnotations;

namespace VehicleControl.CrossCutting.DTO.Marca
{
    public class MarcaInsertDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
