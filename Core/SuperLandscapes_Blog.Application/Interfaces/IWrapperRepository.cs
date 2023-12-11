using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Common;

namespace SuperLandscapes_Blog.Application.Interfaces
{
    public  interface IWrapperRepository : IDisposable
    {
        Task<int> Save(CancellationToken cancellationToken);
        IGenericRepository<T> Repository<T>() where T : AuditableEntity;
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();

    }
}
