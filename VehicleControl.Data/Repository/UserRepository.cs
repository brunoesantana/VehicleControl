﻿using System.Collections.Generic;
using System.Linq;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Base;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Data.Repository
{
    public class UserRepository : BaseRepository<User, UserFilter>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User Login(string login, string password)
        {
            return _context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login) && w.Password.Equals(password));
        }

        public User FindByLogin(string login)
        {
            return _context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login));
        }

        public override List<User> GetAll(UserFilter filter)
        {
            var query = _context.Set<User>().Where(w => w.Active);

            if (!string.IsNullOrWhiteSpace(filter.Term))
                query = query.Where(w => w.UserName == filter.Term);

            return query.OrderBy(a => a.UserName).ToList();
        }
    }
}
