using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleControl.Domain.Base;

namespace VehicleControl.Domain
{
    public class Marca : EntityBase
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(400)")]
        [StringLength(400)]
        public string Description { get; set; }
    }
}
