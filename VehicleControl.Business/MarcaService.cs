using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
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
    }
}
