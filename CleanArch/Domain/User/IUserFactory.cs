using Domain.User.ValueObjects;

namespace Domain.User
{
    public interface IUserFactory
    {
        User NewUser(Name fullname, Birthdate birthdate);
    }
}
