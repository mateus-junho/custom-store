using System.Threading.Tasks;

namespace CustomStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
