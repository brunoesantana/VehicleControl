using VehicleControl.Business.Interface.Base;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Domain;

namespace VehicleControl.Business.Interface
{
    public interface IAnuncioService : IServiceBase<Anuncio, AnuncioFilter>
    {
    }
}
