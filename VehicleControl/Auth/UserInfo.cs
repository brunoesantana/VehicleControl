using System;

namespace VehicleControl.Auth
{
    public class UserInfo
    {
        public UserInfo(Guid id, Guid newGuid, Guid? token)
        {
            Id = id;
            if (token == null) 
                Token = newGuid;

            LastConnection = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid Token { get; set; }
        public DateTime LastConnection { get; set; }
    }
}
