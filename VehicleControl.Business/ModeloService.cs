using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
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
    }
}
