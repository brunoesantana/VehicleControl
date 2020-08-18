using System;
using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Business
{
    public class ModeloService : BaseService<Modelo, ModeloFilter>, IModeloService
    {
        public ModeloService(IModeloRepository repository) : base(repository)
        {
        }

        public ModeloDTO GetModeloDTOFromModeloKey(Guid modeloKey)
        {
            var modelo = Find(modeloKey);

            if (modelo == null) return null;

            return new ModeloDTO
            {
                Id = modelo.Id,
                Name = modelo.Name,
                Detail = modelo.Detail,
                Date = modelo.Date
            };
        }
    }
}
