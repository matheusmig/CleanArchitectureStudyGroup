using System.Threading.Tasks;

namespace Domain.User
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
