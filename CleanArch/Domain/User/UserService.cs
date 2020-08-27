using Domain.User.ValueObjects;
using System.Threading.Tasks;

namespace Domain.User
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
       
        public UserService(
            IUserRepository userRepository,
            IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public async Task<User> CreateNewUser(Name name, Birthdate birthdate)
        {
            var user = _userFactory.NewUser(name, birthdate);
            await _userRepository.AddAsync(user);

            return user;
        }
    }
}
