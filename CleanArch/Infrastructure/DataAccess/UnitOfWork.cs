using Application.Services;
using System;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CleanArchContext _context;
        private bool _disposed;

        public UnitOfWork(CleanArchContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
