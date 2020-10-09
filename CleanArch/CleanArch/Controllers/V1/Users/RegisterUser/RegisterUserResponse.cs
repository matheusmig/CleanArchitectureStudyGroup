using WebApi.ViewModels;

namespace WebApi.Controllers.V1.Users.RegisterUser
{
    public sealed class RegisterUserResponse
    {
        public UserViewModel User { get; }

        public RegisterUserResponse(UserViewModel viewModel)
        {
            User = viewModel;
        }
    }
}
