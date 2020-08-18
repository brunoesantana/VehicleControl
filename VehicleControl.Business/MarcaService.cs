using System;
using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Business
{
    public class MarcaService : BaseService<Marca, MarcaFilter>, IMarcaService
    {
        public MarcaService(IMarcaRepository repository) : base(repository)
        {
        }

        public MarcaDTO GetMarcaDTOFromMarcaKey(Guid marcaKey)
        {
            var marca = Find(marcaKey);

            if (marca == null) return null;

            return new MarcaDTO
            {
                Id = marca.Id,
                Name = marca.Name,
                Description = marca.Description,
                Date = marca.Date
            };
        }
    }
}
