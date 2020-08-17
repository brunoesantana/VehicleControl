using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleControl.CrossCutting.Exceptions;
using VehicleControl.Domain;

namespace VehicleControl.Auth
{
    public class UserManagement
    {
        private static IList<UserInfo> _users;

        public static UserInfo GetUser(Guid token)
        {
            _users = _users ?? new List<UserInfo>();

            var user = _users.FirstOrDefault(f => f.Token.Equals(token));
            if (user == null)
                throw new ForbiddenException();

            return user;
        }

        public static Guid RegisterUser(User profile)
        {
            _users = _users ?? new List<UserInfo>();

            if (!_users.Any(a => a.Id.Equals(profile.Id)))
                _users.Add(new UserInfo(profile.Id, Guid.NewGuid(), null));

            return _users.FirstOrDefault(f => f.Id.Equals(profile.Id)).Token;
        }

        public static void Validate(HttpRequest request)
        {
            var header = request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("authorization"));

            if (!header.Value.ToList().Any())
                throw new PermissionException();

            var tokenRequest = header.Value.ToArray()[0];
            var token = Guid.Empty;

            if (string.IsNullOrEmpty(tokenRequest) || !Guid.TryParse(tokenRequest, out token) || token == Guid.Empty)
                throw new ForbiddenException();

            var user = GetUser(token);
        }
    }
}
