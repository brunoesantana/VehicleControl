using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Business
{
    public class AnuncioService : BaseService<Anuncio, AnuncioFilter>, IAnuncioService
    {
        public AnuncioService(IAnuncioRepository repository) : base(repository)
        {
        }
    }
}
