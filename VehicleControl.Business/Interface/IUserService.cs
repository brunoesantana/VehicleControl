using VehicleControl.Business.Interface.Base;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Domain;

namespace VehicleControl.Business.Interface
{
    public interface IUserService : IServiceBase<User, UserFilter>
    {
        User Login(string login, string password);
    }
}
