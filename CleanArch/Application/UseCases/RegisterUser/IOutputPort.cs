using Application.Services;
using Domain.User;

namespace Application.UseCases.RegisterUser
{
    public interface IOutputPort
    {
        void Ok(User user);
        void Invalid(Notification notification);
    }
}