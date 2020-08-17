using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleControl.Domain.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Date = DateTime.Now;
            Version = 1;
            Active = true;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
