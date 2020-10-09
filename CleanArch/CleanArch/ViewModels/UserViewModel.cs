using Domain.User;

namespace WebApi.ViewModels
{
    public sealed class UserViewModel
    {
        public int Id { get; }
        public string  Name { get; }

        public UserViewModel(User model)
        {
            Id = model.Id;
            Name = model.Name.ToString();
        }
    }
}
