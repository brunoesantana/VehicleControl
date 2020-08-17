using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface.Base;
using VehicleControl.Domain;

namespace VehicleControl.Data.Interface
{
    public interface IUserRepository : IRepositoryBase<User, UserFilter>
    {
        User Login(string login, string password);
        User FindByLogin(string login);
    }
}
