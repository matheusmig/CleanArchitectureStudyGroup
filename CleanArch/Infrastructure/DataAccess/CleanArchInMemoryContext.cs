using System;
using System.Collections.ObjectModel;
using Domain.User;
using Domain.User.ValueObjects;

namespace Infrastructure.DataAccess
{
    public sealed class CleanArchInMemoryContext
    {
        public Collection<User> Users { get; } = new Collection<User>();

        public CleanArchInMemoryContext()
        {
            User user = new User
                {Id = 1, Name = new Name("Romulo Correa"), Birthdate = new Birthdate(new DateTime(2000, 1, 1))};
            Users.Add(user);
        }
    }
}
