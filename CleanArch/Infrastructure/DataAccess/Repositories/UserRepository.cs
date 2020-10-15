using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly CleanArchContext _context;

        public UserRepository(CleanArchContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user)
                .ConfigureAwait(false);
        }

        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}
