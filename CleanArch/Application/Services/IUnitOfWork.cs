using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
