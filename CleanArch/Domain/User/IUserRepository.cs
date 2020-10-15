using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.User
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
