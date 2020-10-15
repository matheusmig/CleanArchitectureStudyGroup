using System;
using System.Collections.Generic;
using System.Text;
using Domain.User;
using Domain.User.ValueObjects;

namespace Infrastructure.DataAccess
{
    public sealed class EntityFactory : IUserFactory
    {
        public User NewUser(Name fullname, Birthdate birthdate)
        {
            return new User {Name = fullname, Birthdate = birthdate};
        }
    }
}
