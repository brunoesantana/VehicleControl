using System;
using VehicleControl.Business.Base;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.Exceptions;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Business
{
    public class UserService : BaseService<User, UserFilter>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public override Guid Create(User dto)
        {
            var user = ((IUserRepository)Repository).FindByLogin(dto.UserName);

            if (user != null && !user.Active)
                throw new NotFoundException();

            return base.Create(dto);
        }

        public override User Update(User dto)
        {
            var user = ((IUserRepository)Repository).Find(dto.Id);
            dto.Password = user.Password;

            return base.Update(dto);
        }

        public User Login(string login, string password)
        {
            var user = ((IUserRepository)Repository).Login(login, password);
            return user ?? throw new NotFoundException();
        }
    }
}
